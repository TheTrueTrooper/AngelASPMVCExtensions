#region WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: July 1,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: To allow Url char replacement mapping for url replace string extention.
//Link: https://github.com/TheTrueTrooper/AngelASPExtentions
//Sources: 
//  {
//  Name: ASP.NetMVC-razor-Example-TaskPlanner 
//  Writer/Publisher:Angelo Sanches (BitSan)
//  Link: https://github.com/TheTrueTrooper/ASP.NetMVC-razor-Example-TaskPlanner
//
//  Name: ASP.net
//  Writer/Publisher: Microsoft
//  Link: https://www.asp.net/
//  }
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelASPExtentions.ExtraClasses
{
    /// <summary>
    /// A class that does mapping to replace charactors 
    /// </summary>
    public class URLReplacementCharMap
    {
        /// <summary>
        /// Thr basic mininmal block list used for setting up a replacement map
        /// </summary>
        public static readonly char[] MinimalBlockList = new char[] { '+', '"', '<', '>', '#', '%', '{', '}', '|', '\\', '^', '~', '[', ']', '`', ';', '/', '?', ':', '@', '=', '&' };

        /// <summary>
        /// The URL charter replavmment map its self
        /// </summary>
        internal Dictionary<char, char> URLCharMap;

        /// <summary>
        /// Gets or sets a char to replace
        /// </summary>
        /// <param name="Char">The char to replace</param>
        /// <returns>The char it becomes</returns>
        public char this[char Char]
        {
            get { return URLCharMap[Char]; }
            set { URLCharMap[Char] = value; }
        }

        /// <summary>
        /// Makes a default replacement map
        /// </summary>
        internal URLReplacementCharMap()
        {
            URLCharMap = new Dictionary<char, char> { { '+', '0' }, { '"', '0' }, { '<', '0' }, { '>', '0' }, { '#', '0' }, { '%', '0' }, { '{', '0' }, { '}', '0' }, { '|', '0' }, { '\\', '0' }, { '^', '0' }, { '~', '0' }, { '[', '0' }, {']', '0' }, {'`', '0' }, {';', '0' }, {'/', '0' }, {'?', '0' }, {':', '0' }, {'@', '0' }, {'=', '0' }, {'&', '0' } };
        }

        /// <summary>
        ///     Makes a brand new replacement map
        /// Throws on
        ///     If the supplied map is missing mini values or is null.
        /// </summary>
        /// <param name="URLCharMapIn">the map to set</param>
        public URLReplacementCharMap(Dictionary<char, char> URLCharMapIn)
        {
            //throw if null
            if (URLCharMapIn == null)
                throw new ArgumentNullException("input is null : URLCharMapIn must not be null");
            // take the list of keys and compare it to the second to see what is missing
            char[] MissingChar = URLCharMapIn.Keys.Except(MinimalBlockList).ToArray();
            //if anything is missing compile a list and throw with list to help the user
            if (MissingChar.Count() > 0)
            {
                string MissingCharList = "The Charaters \"";
                foreach (char c in MissingChar)
                    MissingCharList += "'" + c + "', ";
                MissingCharList.Remove(MissingCharList.Count() - 2, 2);
                MissingCharList += "\" are missing from your list as Minimal replacements. \nURLReplacementCharMap.MinimalBlockList has the full list.";
                throw new Exception(MissingCharList);
            }
            // and Just set it in the end
            URLCharMap = URLCharMapIn;

        }
    }
}

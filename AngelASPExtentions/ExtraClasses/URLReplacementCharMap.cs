using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelASPExtentions.ExtraClasses
{
    public class URLReplacementCharMap
    {
        public static readonly char[] MinimalBlockList = new char[] { '+', '"', '<', '>', '#', '%', '{', '}', '|', '\\', '^', '~', '[', ']', '`', ';', '/', '?', ':', '@', '=', '&' };
        internal Dictionary<char, char> URLCharMap;

        public char this[char Char]
        {
            get { return URLCharMap[Char]; }
            set { URLCharMap[Char] = value; }
        }

        internal URLReplacementCharMap()
        {
            URLCharMap = new Dictionary<char, char> { { '+', '0' }, { '"', '0' }, { '<', '0' }, { '>', '0' }, { '#', '0' }, { '%', '0' }, { '{', '0' }, { '}', '0' }, { '|', '0' }, { '\\', '0' }, { '^', '0' }, { '~', '0' }, { '[', '0' }, {']', '0' }, {'`', '0' }, {';', '0' }, {'/', '0' }, {'?', '0' }, {':', '0' }, {'@', '0' }, {'=', '0' }, {'&', '0' } };
        }

        public URLReplacementCharMap(Dictionary<char, char> URLCharMapIn)
        {
            if (URLCharMapIn == null)
                throw new ArgumentNullException("input is null : URLCharMapIn must not be null");
            char[] MissingChar = URLCharMapIn.Keys.Except(MinimalBlockList).ToArray();
            if (MissingChar.Count() > 0)
            {
                string MissingCharList = "The Charaters \"";
                foreach (char c in MissingChar)
                    MissingCharList += "'" + c + "', ";
                MissingCharList.Remove(MissingCharList.Count() - 2, 2);
                MissingCharList += "\"";
                throw new Exception(MissingCharList);
            }

            URLCharMap = URLCharMapIn;

        }
    }
}

#region WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: June 16,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: Encapsulate the Code to do with Script and Style Extentions for Controller 
//Link: https://github.com/TheTrueTrooper/AngelASPExtentions
//Sources: 
//  {
//  Name: ASP.NetMVC-razor-Example-TaskPlanner 
//  Writer:Angelo Sanches (BitSan)
//  Link: https://github.com/TheTrueTrooper/ASP.NetMVC-razor-Example-TaskPlanner
//  }
#endregion
using AngelASPExtentions.ExtraClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelASPExtentions.ExtraExtentions.Strings
{
    /// <summary>
    /// Adds so string extentions
    /// </summary>
    public static class StringExtentions
    {
        public static URLReplacementCharMap DefaultURLReplacementMap = new URLReplacementCharMap();

        /// <summary>
        /// checks if a string is null or empty
        /// </summary>
        /// <param name="ToCheck">The string to check</param>
        /// <returns>True if null or empty</returns>
        public static bool IsNullEmptyOrWhiteSpace(this string ToCheck)
        {
            return String.IsNullOrWhiteSpace(ToCheck);
        }

        /// <summary>
        /// Replaces the all the char from the keys to the Values 
        /// </summary>
        /// <param name="This">The string to act on</param>
        /// <param name="Map">A Dictionary maping old values(keys) to new values(Values)</param>
        /// <returns>A string with replaced char</returns>
        public static string Replace(this string This, Dictionary<char, char> Map)
        {
            foreach (KeyValuePair<char, char> RKey in Map)
            {
                This = This.Replace(RKey.Key, RKey.Value);
            }
            return This;
        }

        /// <summary>
        /// Replaces the all the char from the keys in URLReplacementCharMap to the Values in the URLReplacementCharMap
        /// </summary>
        /// <param name="This">The string to act on</param>
        /// <param name="Map">A map of all the keys to hit</param>
        /// <returns>A string with replaced ilegal char</returns>
        public static string CleanURLIllegalChars(this string This, URLReplacementCharMap Map = null)
        {
            Map = Map ?? DefaultURLReplacementMap;
            return This.Replace(Map.URLCharMap);
        }

    }
}

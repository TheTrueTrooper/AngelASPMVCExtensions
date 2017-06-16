#region WritersSigniture
//Writer: Angelo Sanches
//Date Writen: June 16,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: Encapsulate the Code to do with Script and Style Extentions for Controller 
//Link: https://github.com/TheTrueTrooper/AngelASPExtentions
//Sources: 
//  {
//  Name: ASP.NetMVC-razor-Example-TaskPlanner 
//  Writer:Angelo Sanches
//  Link: https://github.com/TheTrueTrooper/ASP.NetMVC-razor-Example-TaskPlanner
//  }
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelASPExtentions.ExtraExtentions
{
    /// <summary>
    /// Adds so string extentions
    /// </summary>
    public static class StringExtentions
    {
        /// <summary>
        /// checks if a string is null or empty
        /// </summary>
        /// <param name="ToCheck">The string to check</param>
        /// <returns>True if null or empty</returns>
        public static bool IsNullEmptyOrWhiteSpace(this string ToCheck)
        {
            return String.IsNullOrWhiteSpace(ToCheck);
        }
    }
}

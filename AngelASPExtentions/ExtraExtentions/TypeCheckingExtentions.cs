#region WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: July 24,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: To allow Url char replacement mapping for url replace string extention.
//Link: https://github.com/TheTrueTrooper/AngelASPExtentions
//Sources: 
//  {
//  Name: ASP.NetMVC-razor-Example-TaskPlanner 
//  Writer:Angelo Sanches (BitSan)
//  Link: https://github.com/TheTrueTrooper/ASP.NetMVC-razor-Example-TaskPlanner
//  }
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AngelASPExtentions.ExtraExtentions.Types
{
    public static class TypeCheckingExtentions
    {
        /// <summary>
        /// checks to see if type is primitive
        /// Decimal/Primitive/String/Enum
        /// </summary>
        /// <param name="This">The Type to act on</param>
        /// <returns>If the type is simple</returns>
        public static bool IsSimpleType(this Type This)
        {
            return This.IsPrimitive || This.IsEnum || This.Equals(typeof(string)) || This.Equals(typeof(decimal));
        }

        /// <summary>
        /// Check the complexity of the object
        /// </summary>
        /// <param name="This">The Type to act on</param>
        /// <param name="OutInfo">Outs the PropertyInfos as a list incase you need them</param>
        /// <returns>True if the types are all simple and the base</returns>
        public static bool IsTypeFlat(this Type This,  out List<PropertyInfo> OutInfo)
        {
            OutInfo = new List<PropertyInfo>(This.GetProperties());
            return OutInfo.All(x => x.PropertyType.IsSimpleType());
        }

        /// <summary>
        /// Check the complexity of the object
        /// True if the types are all simple and the base
        /// </summary>
        /// <param name="This">The Type to act on</param>
        /// <returns>True if the types are all simple and the base</returns>
        public static bool IsTypeFlat(this Type This)
        {
            List<PropertyInfo> OutInfo;
            return IsTypeFlat(This, out OutInfo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelASPExtentions.ExtraExtentions
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
    }
}

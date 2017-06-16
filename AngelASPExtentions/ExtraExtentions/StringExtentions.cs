using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelASPExtentions.ExtraExtentions
{
    public static class StringExtentions
    {
        public static bool IsNullEmptyOrWhiteSpace(this string ToCheck)
        {
            return String.IsNullOrWhiteSpace(ToCheck);
        }
    }
}

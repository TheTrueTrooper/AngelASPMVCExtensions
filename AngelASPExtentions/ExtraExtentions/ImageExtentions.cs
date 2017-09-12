using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelASPExtentions.ExtraExtentions
{
    public static class ImageExtentions
    {
        public static byte[] ToByteArray(this Bitmap This)
        {
            var ms = new MemoryStream();
            This.Save(ms, This.RawFormat);
            return ms.ToArray();
        }

        //Convert byte[] array to Image:
        public static Bitmap ToImage(this byte[] This)
        {
            Bitmap Return = null;
            using (MemoryStream MS = new MemoryStream(This))
                Return = new Bitmap(Bitmap.FromStream(MS));
            return Return;
        }

        public static string ToBase64ImageString(this byte[] This)
        {
            return Convert.ToBase64String(This);
        }

        public static string ToBase64ImageString(this Bitmap This)
        {
            return Convert.ToBase64String(This.ToByteArray());
        }
    }
}

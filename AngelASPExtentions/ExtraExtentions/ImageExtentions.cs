#region WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: June 23,2017
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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelASPExtentions.ExtraExtentions.ImageExtentions
{
    public static class ImageExtentions
    {
        /// <summary>
        /// Converts a Bitmap to a byte array for serialization
        /// </summary>
        /// <param name="This">The bitmap to act on</param>
        /// <returns>serializated byte array</returns>
        public static byte[] ToByteArray(this Bitmap This)
        {
            var ms = new MemoryStream();
            This.Save(ms, This.RawFormat);
            return ms.ToArray();
        }

        /// <summary>
        /// Converts a byte array to a Bitmap for deserialization as a image
        /// </summary>
        /// <param name="This">The byte array to act on</param>
        /// <returns>bitmap for an image</returns>
        public static Bitmap ToImage(this byte[] This)
        {
            Bitmap Return = null;
            using (MemoryStream MS = new MemoryStream(This))
                Return = new Bitmap(Bitmap.FromStream(MS));
            return Return;
        }

        /// <summary>
        /// Converts a byte array to a base 64 string for deserialization as a html/xml image data
        /// </summary>
        /// <param name="This">The byte array to act on</param>
        /// <returns>base 64 string for an image</returns>
        public static string ToBase64ImageString(this byte[] This)
        {
            return Convert.ToBase64String(This);
        }

        /// <summary>
        /// Converts a bitmap to a base 64 string for deserialization as a html/xml image data
        /// </summary>
        /// <param name="This">The bitmap to act on</param>
        /// <returns>base 64 string for an image</returns>
        public static string ToBase64ImageString(this Bitmap This)
        {
            return Convert.ToBase64String(This.ToByteArray());
        }
    }
}

#region WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: June 23,2017
//Project Goal: Make a cloud based app to aid in project management 
//File Goal: To add an encapsolated 255 salt and hash encoder
//Link: https://github.com/TheTrueTrooper/AngelASPExtentions
//Sources: 
//  {
//  Name: NA
//  Writer/Publisher: NA
//  Link: NA
//  }
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;

namespace AngelASPExtentions.SecurityHelpers
{
    /// <summary>
    /// A return that contains Salt and SaltedHashedPassword
    /// </summary>
    public struct SecurityReturn
    {
        public string Salt { get; internal set; }
        public string SaltedHashedPassword { get; internal set; }
    }

    /// <summary>
    /// Static Class that returns security like salted and hashed passwords
    /// </summary>
    class SHSecurityHelper
    {
        const int _SaltSize = 32;
        const int _CodeSize = 32;

        /// <summary>
        /// Gets a buffer of letters or random salt should be multiple of 8 but it doesnt matter soo much results will just be the next multiple of 8
        /// </summary>
        /// <param name="size">the Buffer size to use</param>
        /// <returns>the random output string</returns>
        private static string SaltGen(int size)
        {
            byte[] Buf = new byte[size];
            using (RNGCryptoServiceProvider RandomSaltGen = new RNGCryptoServiceProvider())
            {
                RandomSaltGen.GetNonZeroBytes(Buf);
            }

            return Convert.ToBase64String(Buf);
        }

        /// <summary>
        /// Hashes the passwords
        /// </summary>
        /// <param name="String">the password input</param>
        /// <returns>the hashed 44 char hashed string</returns>
        private static string HashString(string String)
        {
            byte[] In = Encoding.UTF8.GetBytes(String);
            byte[] hashed;
            SHA256Managed Hasher = new SHA256Managed();

            hashed = Hasher.ComputeHash(In);

            return Convert.ToBase64String(hashed);
        }

        /// <summary>
        /// Hashes the passwords with a salt input.
        /// Used for rehashing for checks
        /// </summary>
        /// <param name="Password">the password to hash</param>
        /// <param name="Salt">the salt to hash with</param>
        /// <returns>the hashed 44 char hashed string</returns>
        public static string PasswordToSaltedHash(string Password, string Salt)
        {
            return HashString(Password + Salt);
        }

        /// <summary>
        /// Generates and hashes the salt at the same time
        /// </summary>
        /// <param name="Password">the password to hash</param>
        /// <param name="SaltSize">the buffer size to use 32 default</param>
        /// <returns>A struct [SecurityReturn] return for the string locations .Salt .SaltedHashedPassword</returns>
        public static SecurityReturn PasswordToSaltedHash(string Password, int SaltSize = _SaltSize)
        {
            string salt = SaltGen(SaltSize);
            return new SecurityReturn() { Salt = salt, SaltedHashedPassword = HashString(Password + salt) };
        }

        /// <summary>
        /// Gets a buffer of letters or random salt incase you had a use for it or wanted to fo it seperate
        /// </summary>
        /// <param name="size">the Buffer size to use</param>
        /// <returns>the random output string</returns>
        public static string GetCode(int Size = _CodeSize)
        {
            return SaltGen(Size);
        }


    }
}


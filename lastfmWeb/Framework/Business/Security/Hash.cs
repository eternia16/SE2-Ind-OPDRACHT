using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Netflix_Web_App.Framework.Business.Security
{
    /// <summary>
    /// Security class to handle the hashing. I.e password hashing.
    /// </summary>
    public class Hash
    {
        /// <summary>
        /// Preset salt.
        /// </summary>
        private static string SALT = "9EVxuwYeEEsi3ghA2gZbhBBlUm";

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="salt">Custom salt. Completely optional.</param>
        public Hash(string salt = "")
        {
            if (salt != "")
                Hash.SALT = salt;
        }

        /// <summary>
        /// Turning the input into SHA256 hash plus salt.
        /// </summary>
        /// <param name="entry">Input of the user, could be a password or such.</param>
        /// <returns>Hashed entry</returns>
        public static string SHA256Hash(string entry)
        {
            byte[] hashedDataBytes = new SHA256Managed().ComputeHash(
                new UTF8Encoding().GetBytes(
                    String.Concat(entry, SALT)
                    )
                );

            return String.Concat(byteArrayToString(hashedDataBytes), SALT);
        }

        /// <summary>
        /// Converts byte array into string object.
        /// </summary>
        /// <param name="inputArray">byte array</param>
        /// <returns>A string</returns>
        public static string byteArrayToString(byte[] inputArray)
        {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < inputArray.Length; i++)
            {
                output.Append(inputArray[i].ToString("X2"));
            }
            return output.ToString();
        }

        /// <summary>
        /// Calculates the length of the string.
        /// </summary>
        /// <returns>Int the with number of length.</returns>
        public static int SHA526LengthSalt()
        {
            return 64 + SALT.Length;
        }
    }
}
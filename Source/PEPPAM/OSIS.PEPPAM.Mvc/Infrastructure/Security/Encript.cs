using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace OSIS.PEPPAM.Mvc.Infrastructure.Security
{
    public class Encript
    {
      
        private const int SaltValueSize = 4;

        // Hashing algorithms used to verify one-way-hashed passwords:
        // MD5 is used for backward compatibility with Commerce Server 2002. If you have no legacy data, MD5 can be removed.
        // SHA256 is used on Windows Server 2003.
        // SHA1 should be used on Windows XP (SHA256 is not supported).
        private static string[] HashingAlgorithms = new string[] { "SHA256", "MD5" };

        
        public static bool VerifyHashedPassword(string passwordInserted, string passwordSaved)
        {
            int saltLength = SaltValueSize * UnicodeEncoding.CharSize;

            if (string.IsNullOrEmpty(passwordSaved) ||
                string.IsNullOrEmpty(passwordInserted) ||
                passwordSaved.Length < saltLength)
            {
                return false;
            }

            // Strip the salt value off the front of the stored password.
            string saltValue = passwordSaved.Substring(0, saltLength);

            foreach (string hashingAlgorithmName in HashingAlgorithms)
            {
                HashAlgorithm hash = HashAlgorithm.Create(hashingAlgorithmName);
                string hashedPassword = HashPassword(passwordInserted, saltValue, hash);
                if (passwordSaved.Equals(hashedPassword, StringComparison.Ordinal))
                    return true;
            }

            // None of the hashing algorithms could verify the password.
            return false;
        }



        private static string GenerateSaltValue()
        {
            UnicodeEncoding utf16 = new UnicodeEncoding();

            if (utf16 != null)
            {
                // Create a random number object seeded from the value
                // of the last random seed value. This is done
                // interlocked because it is a static value and we want
                // it to roll forward safely.

                Random random = new Random(unchecked((int)DateTime.Now.Ticks));

                if (random != null)
                {
                    // Create an array of random values.

                    byte[] saltValue = new byte[SaltValueSize];

                    random.NextBytes(saltValue);

                    // Convert the salt value to a string. Note that the resulting string
                    // will still be an array of binary values and not a printable string. 
                    // Also it does not convert each byte to a double byte.

                    string saltValueString = utf16.GetString(saltValue);

                    // Return the salt value as a string.

                    return saltValueString;
                }
            }

            return null;
        }

        public static string HashPassword(string clearData, string saltValue, HashAlgorithm hash)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();

            if (clearData != null && hash != null && encoding != null)
            {
                // If the salt string is null or the length is invalid then
                // create a new valid salt value.

                if (saltValue == null)
                {
                    // Generate a salt string.
                    saltValue = GenerateSaltValue();
                }

                // Convert the salt string and the password string to a single
                // array of bytes. Note that the password string is Unicode and
                // therefore may or may not have a zero in every other byte.

                byte[] binarySaltValue = new byte[SaltValueSize];

                binarySaltValue[0] = byte.Parse(saltValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[1] = byte.Parse(saltValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[2] = byte.Parse(saltValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[3] = byte.Parse(saltValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);

                byte[] valueToHash = new byte[SaltValueSize + encoding.GetByteCount(clearData)];
                byte[] binaryPassword = encoding.GetBytes(clearData);

                // Copy the salt value and the password to the hash buffer.

                binarySaltValue.CopyTo(valueToHash, 0);
                binaryPassword.CopyTo(valueToHash, SaltValueSize);

                byte[] hashValue = hash.ComputeHash(valueToHash);

                // The hashed password is the salt plus the hash value (as a string).

                string hashedPassword = saltValue;

                foreach (byte hexdigit in hashValue)
                {
                    hashedPassword += hexdigit.ToString("X2", CultureInfo.InvariantCulture.NumberFormat);
                }

                // Return the hashed password as a string.

                return hashedPassword;
            }

            return null;
        }
    }
}
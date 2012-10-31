using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Unicorn.Security
{
    /// <summary>
    /// Represents a class that can be used to create and verify of password using SHA1 algorithm.
    /// </summary>
    public class Password
    {
        /// <summary>
        /// SHA1 hash value for the specified password
        /// in string representation
        /// </summary>
        private string _hash;

        /// <summary>
        /// Salt value for the specified password
        /// in string representation
        /// </summary>
        private string _salt;

        /// <summary>
        /// Initializes a new instance of the Password class.
        /// </summary>
        /// <param name="rawPassword">The raw string password.</param>
        public Password(string rawPassword)
        {
            this._salt = GenerateRandom(5);
            this._hash = ComputeHash(this._salt + rawPassword);
        }

        /// <summary>
        /// Initializes a new instance of the Password class.
        /// </summary>
        /// <param name="salt">The salt of password string.</param>
        /// <param name="hash">The SHA1 hash.</param>
        public Password(string salt, string hash)
        {
            this._salt = salt;
            this._hash = hash;
        }

        /// <summary>
        /// Compares two specified chars objects and returns an
        /// value that indicates two compared are equal.
        /// </summary>
        /// <param name="a">The first char to compare.</param>
        /// <param name="b">The second char to compare.</param>
        /// <param name="ignoreCase">true to ignore case during the comparison; otherwise, false. </param>
        /// <returns>A Boolean value that indicates the lexical relationship between the two compared.</returns>
        private bool CompareChar(char a, char b, bool ignoreCase)
        {
            return (string.Compare(a.ToString(), b.ToString(), ignoreCase) == 0);
        }

        /// <summary>
        /// Creates an instance of the default implementation of a cryptographic random number generator that 
        /// used to generate random data string.
        /// </summary>
        /// <param name="size">The length of the random data string.</param>
        /// <returns>Random string</returns>
        private static string GenerateRandom(int size)
        {
            byte[] random = new byte[size];
            RandomNumberGenerator.Create().GetBytes(random);
            return Convert.ToBase64String(random);
        }

        /// <summary>
        /// Computes the hash value for the specified string.
        /// </summary>
        /// <param name="value">The input to compute the hash code for.</param>
        /// <returns>The computed hash code in string representation.</returns>
        private static string ComputeHash(string value)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] buffer = Encoding.UTF8.GetBytes(value);
            byte[] hash = sha1.ComputeHash(buffer, 0, buffer.Length);
            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Verifies the data referenced in an already created password.
        /// </summary>
        /// <param name="password">The object actually to be used to verify.</param>
        /// <returns>>A Boolean value that indicates verification result.</returns>
        public bool Verify(string password)
        {
            string hash = ComputeHash(this._salt + password);
            if (hash.Length == this._hash.Length)
            {
                for (int i = 0; i < hash.Length; i++)
                {
                    if (!this.CompareChar(hash[i], this._hash[i], true))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// SHA1 hash value for the specified password
        /// in string representation
        /// </summary>
        public string Hash
        {
            get
            {
                return this._hash;
            }
            set
            {
                this._hash = value;
            }
        }

        /// <summary>
        /// Salt value for the specified password
        /// in string representation
        /// </summary>
        public string Salt
        {
            get
            {
                return this._salt;
            }
            set
            {
                this._salt = value;
            }
        }
    }
}

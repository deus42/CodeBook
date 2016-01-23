// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Caesar.cs" company="MadnessSolitions">
//   Deus
// </copyright>
// <summary>
//   The caesar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CodeBook.Ciphers
{
    using System;
    using CodeBook.Ciphers.Interfaces;

    /// <summary>
    /// The caesar.
    /// </summary>
    public class Caesar : ICipher
    {
        /// <summary>
        /// The shift.
        /// </summary>
        private readonly int shift;

        /// <summary>
        /// The Alphabet.
        /// </summary>
        private readonly char[] alphabet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Caesar"/> class.
        /// </summary>
        /// <param name="alphabet">
        /// The alphabet.
        /// </param>
        /// <param name="shift">
        /// The shift.
        /// </param>
        public Caesar(char[] alphabet, int shift = 2)
        {
            this.alphabet = alphabet;
            this.shift = shift;
        }

        /// <summary>
        /// Encrypt message in plaintext.
        /// </summary>
        /// <param name="plaintext">Message in plaintext.</param>
        /// <returns>A Ciphertext</returns>
        public string Encrypt(string plaintext)
        {
            string ciphertext = string.Empty;
            foreach (var c in plaintext)
            {
                if (char.IsWhiteSpace(c))
                {
                    ciphertext += c;
                    continue;
                }

                int index = (Array.IndexOf(this.alphabet, c) + this.shift + this.alphabet.Length) % this.alphabet.Length;
                ciphertext += this.alphabet[index];
            }

            return ciphertext;
        }

        /// <summary>
        /// Decrypt ciphertext
        /// </summary>
        /// <param name="ciphertext">A Ciphertext</param>
        /// <returns>A Plaintext</returns>
        public string Decrypt(string ciphertext)
        {
            string plaintext = string.Empty;
            foreach (var c in ciphertext)
            {
                if (char.IsWhiteSpace(c))
                {
                    plaintext += c;
                    continue;
                }

                int index = (Array.IndexOf(this.alphabet, c) - this.shift + this.alphabet.Length) % this.alphabet.Length;
                plaintext += this.alphabet[index];
            }

            return plaintext;
        }
    }
}

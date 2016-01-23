// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vingenere.cs" company="MadnessSolutions">
//   Deus
// </copyright>
// <summary>
//   Defines the Vingenere type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CodeBook.Ciphers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    using CodeBook.Ciphers.Interfaces;

    /// <summary>
    /// The Vingenere cipher.
    /// </summary>
    public class Vingenere : ICipher
    {
        /// <summary>
        /// The matrix.
        /// </summary>
        private readonly char[][] matrix;

        /// <summary>
        /// The keyword.
        /// </summary>
        private readonly string keyword;

        /// <summary>
        /// The alphabet.
        /// </summary>
        private readonly char[] alphabet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vingenere"/> class.
        /// </summary>
        /// <param name="alphabet">The alphabet.</param>
        /// <param name="keyword">The keyword.</param>
        public Vingenere(char[] alphabet, string keyword)
        {
            var key = keyword.Distinct().ToList();
            int x = alphabet.Length;
            int y = key.Count;
            int c = 0;
            this.matrix = new char[y][];
            for (int i = 0; i < x; i++)
            {
                if (key.Contains(alphabet[i]))
                {
                    this.matrix[c] = new char[x];
                    for (int j = 0; j < x; j++)
                    {
                        int index = (i + j) % x;
                        this.matrix[c][j] = alphabet[index];
                    }

                    c++;
                }
            }

            this.keyword = keyword;
            this.alphabet = alphabet;
        }

        /// <summary>
        /// The encrypt.
        /// </summary>
        /// <param name="plaintext">A plaintext.</param>
        /// <returns>
        /// Ciphertext <see cref="string"/>.
        /// </returns>
        public string Encrypt(string plaintext)
        {
            string ciphertext = string.Empty;
            plaintext = Regex.Replace(plaintext, @"\s+", string.Empty);
            for (int i = 0; i < plaintext.Length; i++)
            {
                for (int j = 0; j < this.keyword.Length; j++)
                {
                    // we found a row
                    if (this.matrix[j][0] == this.keyword[i % this.keyword.Length])
                    {
                        var charIndex = Array.IndexOf(this.alphabet, plaintext[i]);
                        ciphertext += this.matrix[j][charIndex];
                    }
                }
            }

            return ciphertext;
        }

        /// <summary>
        /// The decrypt.
        /// </summary>
        /// <param name="ciphertext">A Ciphertext.</param>
        /// <returns>
        /// A plaintext <see cref="string"/>.
        /// </returns>
        public string Decrypt(string ciphertext)
        {
            string plaintext = string.Empty;

            for (int i = 0; i < ciphertext.Length; i++)
            {
                for (int j = 0; j < this.keyword.Length; j++)
                {
                    if (this.matrix[j][0] == this.keyword[i % this.keyword.Length])
                    {
                        // we found a row
                        var charIndex = Array.IndexOf(this.matrix[j], ciphertext[i]);
                        plaintext += this.alphabet[charIndex];
                    }
                }
            }

            return plaintext;
        }
    }
}

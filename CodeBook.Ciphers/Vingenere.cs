// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vingenere.cs" company="MadnessSolutions">
//   Deus
// </copyright>
// <summary>
//   Defines the Vingenere type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Text.RegularExpressions;
using CodeBook.Ciphers.Interfaces;

namespace CodeBook.Ciphers
{
    /// <summary>
    ///     The Vingenere cipher.
    /// </summary>
    public class Vingenere : ICipher
    {
        /// <summary>
        ///     The alphabet.
        /// </summary>
        private readonly char[] alphabet;

        /// <summary>
        ///     The keyword.
        /// </summary>
        private readonly string keyword;

        /// <summary>
        ///     The matrix.
        /// </summary>
        private readonly char[][] matrix;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Vingenere" /> class.
        /// </summary>
        /// <param name="alphabet">The alphabet.</param>
        /// <param name="keyword">The keyword.</param>
        public Vingenere(char[] alphabet, string keyword)
        {
            var key = keyword.Distinct().ToList();
            var x = alphabet.Length;
            var y = key.Count;
            var c = 0;
            this.matrix = new char[y][];
            for (var i = 0; i < x; i++)
            {
                if (key.Contains(alphabet[i]))
                {
                    this.matrix[c] = new char[x];
                    for (var j = 0; j < x; j++)
                    {
                        var index = (i + j)%x;
                        this.matrix[c][j] = alphabet[index];
                    }

                    c++;
                }
            }

            this.keyword = keyword;
            this.alphabet = alphabet;
        }

        /// <summary>
        ///     The encrypt.
        /// </summary>
        /// <param name="plaintext">A plaintext.</param>
        /// <returns>
        ///     Ciphertext <see cref="string" />.
        /// </returns>
        public string Encrypt(string plaintext)
        {
            var ciphertext = string.Empty;
            plaintext = Regex.Replace(plaintext, @"\s+", string.Empty);
            for (var i = 0; i < plaintext.Length; i++)
            {
                for (var j = 0; j < this.keyword.Length; j++)
                {
                    // we found a row
                    if (this.matrix[j][0] == this.keyword[i%this.keyword.Length])
                    {
                        var charIndex = Array.IndexOf(this.alphabet, plaintext[i]);
                        ciphertext += this.matrix[j][charIndex];
                    }
                }
            }

            return ciphertext;
        }

        /// <summary>
        ///     The decrypt.
        /// </summary>
        /// <param name="ciphertext">A Ciphertext.</param>
        /// <returns>
        ///     A plaintext <see cref="string" />.
        /// </returns>
        public string Decrypt(string ciphertext)
        {
            var plaintext = string.Empty;

            for (var i = 0; i < ciphertext.Length; i++)
            {
                for (var j = 0; j < this.keyword.Length; j++)
                {
                    if (this.matrix[j][0] == this.keyword[i%this.keyword.Length])
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
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeywordCipher.cs" company="MadnessSolitions">
//   Deus
// </copyright>
// <summary>
//   Defines the KeywordCipher type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBook.Ciphers
{
    /// <summary>
    ///     The keyed Сaesar cipher.
    /// </summary>
    public class KeywordCipher : ICipher
    {
        /// <summary>
        ///     The cipher dictionary.
        /// </summary>
        private readonly Dictionary<char, char> cipherDictionary = new Dictionary<char, char>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeywordCipher" /> class.
        /// </summary>
        /// <param name="alphabet">The alphabet.</param>
        /// <param name="keyphrase">The keyphrase.</param>
        /// <param name="shift">The shift. </param>
        /// <exception cref="FormatException">Format exception.</exception>
        public KeywordCipher(char[] alphabet, string keyphrase, int shift = 0)
        {
            if (alphabet == null || alphabet.Length == 0)
            {
                throw new FormatException("Alphabets is not well formed or empty!");
            }

            if (string.IsNullOrEmpty(keyphrase))
            {
                throw new FormatException("Keyphrase is empty!");
            }

            var key = keyphrase.Distinct().ToList();
            var cipheralphabet = key.Concat(alphabet.Except(key)).ToArray();

            if (alphabet.Length != cipheralphabet.Length)
            {
                throw new FormatException("Alphabets doesn't contain all symbols from the keyphrase!");
            }

            for (var i = 0; i < alphabet.Length; i++)
            {
                this.cipherDictionary.Add(alphabet[i], cipheralphabet[i]);
            }
        }

        /// <summary>
        ///     Encrypt plaintext.
        /// </summary>
        /// <param name="plaintext"> The plaintext. </param>
        /// <returns>Ciphertext <see cref="string" />. </returns>
        public string Encrypt(string plaintext)
        {
            var ciphertext = string.Empty;
            foreach (var symbol in plaintext)
            {
                if (char.IsWhiteSpace(symbol))
                {
                    ciphertext += symbol;
                    continue;
                }

                ciphertext += this.cipherDictionary[symbol];
            }

            return ciphertext;
        }

        /// <summary>
        ///     The decrypt.
        /// </summary>
        /// <param name="ciphertext">The ciphertext.</param>
        /// <returns>
        ///     Plaintext <see cref="string" />.
        /// </returns>
        public string Decrypt(string ciphertext)
        {
            var plaintext = string.Empty;
            foreach (var symbol in ciphertext)
            {
                if (char.IsWhiteSpace(symbol))
                {
                    plaintext += symbol;
                    continue;
                }

                plaintext += this.cipherDictionary.First(c => c.Value == symbol).Key;
            }

            return plaintext;
        }
    }
}
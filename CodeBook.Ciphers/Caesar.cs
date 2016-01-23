using System;

namespace CodeBook.Ciphers
{
    public class Caesar : ICipher
    {
        private readonly int _shift;
        private readonly char[] _alphabet;

        public Caesar(char[] alphabet, int shift = 2)
        {
            _alphabet = alphabet;
            _shift = shift;
        }

        /// <summary>
        /// Encrypt message in plaintext
        /// </summary>
        /// <param name="plaintext">Message in plaintext</param>
        /// <returns>Ciphertext</returns>
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
                int index = (Array.IndexOf(_alphabet, c) + _shift + _alphabet.Length) % _alphabet.Length;
                ciphertext += _alphabet[index];
            }
            return ciphertext;
        }

        /// <summary>
        /// Decrypt ciphertext
        /// </summary>
        /// <param name="ciphertext">Ciphertext</param>
        /// <returns>Plaintext</returns>
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
                int index = (Array.IndexOf(_alphabet, c) - _shift + _alphabet.Length) % _alphabet.Length;
                plaintext += _alphabet[index];
            }
            return plaintext;
        }
    }
}

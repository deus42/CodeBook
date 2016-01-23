using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBook.Ciphers
{
    public class KeyedCaesar : ICipher
    {
        private readonly Dictionary<char, char> _cipherDictionary = new Dictionary<char, char>();

        public KeyedCaesar(char[] alphabet, string keyphrase, int shift = 0)
        {
            if (alphabet == null || alphabet.Length == 0)
                throw new FormatException("Alphabet is not well formed or empty!");
            if (string.IsNullOrEmpty(keyphrase))
                throw new FormatException("Keyphrase is empty!");
            
            var key = keyphrase.Distinct();
            var cipheralphabet = key.Concat(alphabet.Except(key)).ToArray();

            if(alphabet.Length != cipheralphabet.Length)
                throw new FormatException("Alphabet doesn't contain all symbols from the keyphrase!");

            for (int i = 0; i < alphabet.Length; i++)
            {
                _cipherDictionary.Add(alphabet[i], cipheralphabet[i]);
            }
 
        }

        public string Encrypt(string plaintext)
        {
            string ciphertext = string.Empty;
            foreach (var symbol in plaintext)
            {
                ciphertext += _cipherDictionary[symbol];
            }
            return ciphertext;
        }

        public string Decrypt(string ciphertext)
        {
            string plaintext = string.Empty;
            foreach (var symbol in ciphertext)
            {
                plaintext += _cipherDictionary.First(c => c.Value == symbol).Key;
            }
            return plaintext;
        }
    }
}

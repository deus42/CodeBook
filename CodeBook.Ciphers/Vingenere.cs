using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace CodeBook.Ciphers
{
    public class Vingenere : ICipher
    {
        private char[][] _matrix;
        private string _keyword;
        private char[] _alphabet;

        public Vingenere(char[] alphabet, string keyword)
        {
            var key = keyword.Distinct();
            int x = alphabet.Length;
            int y = key.Count();
            int c = 0;
            char[][] matrix = new char[y][];
            for (int i = 0; i < x; i++)
            {
                if (key.Contains(alphabet[i]))
                {
                    matrix[c] = new char[x];
                    for (int j = 0; j < x; j++)
                    {
                        int index = (i + j) % x;
                        matrix[c][j] = alphabet[index];
                    }
                    c++;
                }
            }
            _matrix = matrix;
            _keyword = keyword;
            _alphabet = alphabet;
        }

        public string Encrypt(string plaintext)
        {
            string ciphertext = string.Empty;
            plaintext = Regex.Replace(plaintext, @"\s+", string.Empty);
            for (int i = 0; i < plaintext.Length; i++)
            {
                for (int j = 0; j < _keyword.Length; j++)
                {
                    if (_matrix[j][0] == _keyword[i % _keyword.Length]) //we found a row
                    {
                        var charIndex = Array.IndexOf(_alphabet, plaintext[i]);
                        ciphertext += _matrix[j][charIndex];
                    }
                }

            }
            return ciphertext;
        }

        public string Decrypt(string ciphertext)
        {
            string plaintext = string.Empty;

            for (int i = 0; i < ciphertext.Length; i++)
            {
                for (int j = 0; j < _keyword.Length; j++)
                {
                    if (_matrix[j][0] == _keyword[i % _keyword.Length]) //we found a row
                    {
                        var charIndex = Array.IndexOf(_matrix[j], ciphertext[i]);
                        plaintext += _alphabet[charIndex];
                    }
                }

            }
            return plaintext;
        }
    }
}

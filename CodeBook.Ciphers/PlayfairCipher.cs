using System;
using System.Linq;
using CodeBook.Languages;

namespace CodeBook.Ciphers
{
    /// <summary>
    ///     Playfair cipher. Only English lowercase for now.
    /// </summary>
    public class PlayfairCipher : ICipher
    {
        private const int AlphabetCount = 25;
        private readonly char[][] matrix = new char[5][];

        /// <summary>
        ///     Constructor. 5x5 matrix for English alphabet. Excluding 'j'.
        /// </summary>
        /// <param name="keyword">Keyword avoiding J (will be ignored)</param>
        public PlayfairCipher(string keyword)
        {
            var key = keyword.Distinct().Where(c => c != 'j').ToList();
            var alphabet = key.Concat(Alphabets.English26.Where(c => c != 'j').Except(key)).ToArray();
            if (alphabet.Length != AlphabetCount)
            {
                throw new ArgumentException($"Alphabet should be {AlphabetCount} length!");
            }
            
            var j = 0;
            for (var i = 0; i < alphabet.Length; i++)
            {
                if (i > 0 && i%5 == 0) j++;

                if (this.matrix[j] == null)
                {
                    this.matrix[j] = new char[5];
                }

                this.matrix[j][i%5] = alphabet[i];
            }
        }

        public string Encrypt(string plaintext)
        {
            throw new NotImplementedException();
        }

        public string Decrypt(string ciphertext)
        {
            throw new NotImplementedException();
        }
    }
}
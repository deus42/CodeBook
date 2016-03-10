using System;

namespace CodeBook.Languages
{
    /// <summary>
    /// English language.
    /// </summary>
    public class English : ILanguage
    {
        private readonly char[] alphabet;

        public English(char[] alphabet = null)
        {
            this.alphabet = alphabet ?? Alphabet.English26;
        }

        /// <summary>
        /// Rotates a text.
        /// </summary>
        /// <param name="text">Text to rotate.</param>
        /// <param name="shift">Shift of the rotation.</param>
        /// <returns></returns>
        public string RotateText(string text, int shift)
        {
            string result = string.Empty;
            foreach (var c in text)
            {
                var index = (Array.IndexOf(this.alphabet, c) + shift + this.alphabet.Length) % this.alphabet.Length;
                result += this.alphabet[index];
            }
            return result;
        }
    }
}

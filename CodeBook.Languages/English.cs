using System;

namespace CodeBook.Languages
{
    /// <summary>
    /// English language.
    /// </summary>
    public class English : ILanguage
    {
        public char[] Alphabet { get; }

        public English(char[] alphabet = null)
        {
            Alphabet = alphabet ?? Alphabets.English26;
        }

        /// <summary>
        /// Rotates a text.
        /// </summary>
        /// <param name="text">Text to rotate.</param>
        /// <param name="shift">Shift of the rotation.</param>
        /// <returns>Shifted text.</returns>
        public string RotateText(string text, int shift)
        {
            string result = string.Empty;
            foreach (var c in text)
            {
                var index = (Array.IndexOf(Alphabet, c) + shift + Alphabet.Length) % Alphabet.Length;
                result += Alphabet[index];
            }
            return result;
        }
    }
}

using System;
using System.Linq;
using PlatformSpellCheck;

namespace CodeBook.Languages
{
    public class Dictionary : IDisposable
    {
        public readonly SpellChecker Spelling;

        public Dictionary(string language = "en-US")
        {
            this.Spelling = new SpellChecker(language);
        }

        public void Dispose()
        {
            this.Spelling.Dispose();
        }

        public bool SpellCheck(string word)
        {
            var result = this.Spelling.Check(word).ToList();
            return !result.Any();
        }
    }
}
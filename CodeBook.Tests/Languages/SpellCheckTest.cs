using CodeBook.Languages;
using NUnit.Framework;

namespace CodeBook.Tests.Languages
{
    /// <summary>
    /// Spell checker tests. Please note that Spanish must be installed in your system.
    /// </summary>
    [TestFixture]
    public class SpellCheckTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void TestSpellCheck_English()
        {
            var spellchecker = new Dictionary();
            var result = spellchecker.SpellCheck("word");
            Assert.IsTrue(result);

            // try garbish
            var badresult = spellchecker.SpellCheck("worrd");
            Assert.IsFalse(badresult);


            // try Spanish
            badresult = spellchecker.SpellCheck("mujer");
            Assert.IsFalse(badresult);
        }

        [Test]
        public void TestSpellCheck_Spanish()
        {
            var spellchecker = new Dictionary("es");

            var result = spellchecker.SpellCheck("palabra");
            Assert.IsTrue(result);

            var badresult = spellchecker.SpellCheck("word");
            Assert.IsFalse(badresult);
        }
    }
}
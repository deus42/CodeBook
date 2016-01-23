using System.Text.RegularExpressions;
using CodeBook.Ciphers;
using NUnit.Framework;

namespace CodeBook.Tests
{
    [TestFixture]
    class VingenereTest : BaseTest
    {
        private string Ciphertext = "zpdxvpazhslzbhiwzbkmznm";

        [Test]
        public override void EncryptTest()
        {
            var vingenere = new Vingenere(Alphabet.English26, Keyword);
            var ciphertext = vingenere.Encrypt(Message);
            Assert.AreEqual(ciphertext, Ciphertext);
        }

        [Test]
        public override void DecryptTest()
        {
            var vingenere = new Vingenere(Alphabet.English26, Keyword);
            var plaintext = vingenere.Decrypt(Ciphertext);
            var messageWithoutWhitespaces = Regex.Replace(Message, @"\s+", string.Empty);
            Assert.AreEqual(plaintext, messageWithoutWhitespaces);
        }
    }
}

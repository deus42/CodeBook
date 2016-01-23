using CodeBook.Ciphers;
using NUnit.Framework;

namespace CodeBook.Tests
{
    [TestFixture]
    public class KeyedCaesarTest : BaseTest
    {
        protected const string Ciphertext = "bububfbebgbfb";

        [Test]
        public override void EncryptTest()
        {
            var cipher = new KeyedCaesar(Alphabet.English26, Keyphrase);
            var ciphertext = cipher.Encrypt(Message);
            Assert.AreEqual(ciphertext, Ciphertext);
        }

        [Test]
        public override void DecryptTest()
        {
            var cipher = new KeyedCaesar(Alphabet.English26, Keyphrase);
            var plaintext = cipher.Decrypt(Ciphertext);
            Assert.AreEqual(plaintext, Message);
        }
    }
}

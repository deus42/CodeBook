using System;
using CodeBook.Ciphers;
using NUnit.Framework;

namespace CodeBook.Tests.Ciphers
{
    [TestFixture]
    public class PlayfairCipherTest : BaseCipherTest
    {
        public string Ciphertext = "";

        [Test]
        public override void EncryptTest()
        {
            var playfair = new PlayfairCipher(Keyword);
            var ciphertext = playfair.Encrypt(Message);
            Assert.AreEqual(ciphertext, this.Ciphertext);
        }

        [Test]
        public override void DecryptTest()
        {
            throw new NotImplementedException();
        }


    }
}
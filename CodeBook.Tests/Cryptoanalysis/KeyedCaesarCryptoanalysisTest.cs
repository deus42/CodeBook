using CodeBook.Cryptoanalysis;
using CodeBook.Languages;
using NUnit.Framework;

namespace CodeBook.Tests.Cryptoanalysis
{
    [TestFixture]
    public class KeyedCaesarCryptoanalysisTest : BaseCryptoanalysisTest
    {
        protected const string Ciphertext = "ilvnprrpjjkqrjnbqrplifn";

        [Test]
        public void KeyedCaesarCryptoanalisysTest()
        {
            var caesarCryptoanalysis = new KeyedCaesarCryptoanalysis();
            var plaintext = caesarCryptoanalysis.Process(Ciphertext);
            Assert.AreEqual(plaintext, Message.Replace(" ", ""));
        }
    }
}

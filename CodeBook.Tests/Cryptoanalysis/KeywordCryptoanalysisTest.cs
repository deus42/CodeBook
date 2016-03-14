using CodeBook.Cryptoanalysis;
using CodeBook.Languages;
using NUnit.Framework;

namespace CodeBook.Tests.Cryptoanalysis
{
    [TestFixture]
    public class KeywordCryptoanalysisTest : BaseCryptoanalysisTest
    {
        protected const string Ciphertext = "ilvnprrpjjkqrjnbqrplifn";

        [Test]
        public void KeywordCryptoanalysis()
        {
            var caesarCryptoanalysis = new KeywordCryptoanalysis();
            var plaintext = caesarCryptoanalysis.Process(Ciphertext);
            Assert.AreEqual(plaintext, Message.Replace(" ", ""));
        }
    }
}

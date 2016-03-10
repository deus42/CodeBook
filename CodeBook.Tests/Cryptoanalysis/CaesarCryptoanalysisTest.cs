using CodeBook.Cryptoanalysis;
using CodeBook.Languages;
using NUnit.Framework;

namespace CodeBook.Tests.Cryptoanalysis
{
    [TestFixture]
    public class CaesarCryptoanalysisTest : BaseCryptoanalysisTest
    {
        protected const string Ciphertext = "inajwyywttuxytjfxywnilj";

        [Test]
        public void CaesarCryptoanalisysTest()
        {
            var caesarCryptoanalysis = new CaesarCryptoanalysis();
            var plaintext = caesarCryptoanalysis.Process(Ciphertext);
            Assert.AreEqual(plaintext, Message.Replace(" ", ""));
        }
    }
}

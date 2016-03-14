// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeywordCipherTest.cs" company="MadnessSolutions">
//   Deus
// </copyright>
// <summary>
//   Defines the KeywordCipherTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using CodeBook.Ciphers;
using CodeBook.Languages;
using NUnit.Framework;

namespace CodeBook.Tests.Ciphers
{
    /// <summary>
    ///     The keyed caesar test.
    /// </summary>
    [TestFixture]
    public class KeywordCipherTest : BaseCipherTest
    {
        /// <summary>
        ///     The ciphertext.
        /// </summary>
        protected const string Ciphertext = "ilvnpr rpjjkq rj nbqr plifn";

        /// <summary>
        ///     The decrypt test.
        /// </summary>
        [Test]
        public override void DecryptTest()
        {
            var cipher = new KeywordCipher(Alphabets.English26, Keyphrase);
            var plaintext = cipher.Decrypt(Ciphertext);
            Assert.AreEqual(Message, plaintext);
        }

        /// <summary>
        ///     The encrypt test.
        /// </summary>
        [Test]
        public override void EncryptTest()
        {
            var cipher = new KeywordCipher(Alphabets.English26, Keyphrase);
            var ciphertext = cipher.Encrypt(Message);
            Assert.AreEqual(Ciphertext, ciphertext);
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyedCaesarTest.cs" company="MadnessSolutions">
//   Deus
// </copyright>
// <summary>
//   Defines the KeyedCaesarTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CodeBook.Tests
{
    using CodeBook.Ciphers;

    using NUnit.Framework;

    /// <summary>
    /// The keyed caesar test.
    /// </summary>
    [TestFixture]
    public class KeyedCaesarTest : BaseTest
    {
        /// <summary>
        /// The ciphertext.
        /// </summary>
        protected const string Ciphertext = "ilvnpr rpjjkq rj nbqr plifn";

        /// <summary>
        /// The encrypt test.
        /// </summary>
        [Test]
        public override void EncryptTest()
        {
            var cipher = new KeyedCaesar(Alphabet.English26, Keyphrase);
            var ciphertext = cipher.Encrypt(Message);
            Assert.AreEqual(Ciphertext, ciphertext);
        }

        /// <summary>
        /// The decrypt test.
        /// </summary>
        [Test]
        public override void DecryptTest()
        {
            var cipher = new KeyedCaesar(Alphabet.English26, Keyphrase);
            var plaintext = cipher.Decrypt(Ciphertext);
            Assert.AreEqual(Message, plaintext);
        }
    }
}

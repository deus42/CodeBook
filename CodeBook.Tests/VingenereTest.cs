// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VingenereTest.cs" company="MadnessSolutions">
//   Deus
// </copyright>
// <summary>
//   The vingenere test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CodeBook.Tests
{
    using System.Text.RegularExpressions;

    using CodeBook.Ciphers;

    using NUnit.Framework;

    /// <summary>
    /// The vingenere test.
    /// </summary>
    [TestFixture]
    public class VingenereTest : BaseTest
    {
        /// <summary>
        /// The ciphertext.
        /// </summary>
        protected const string Ciphertext = "zpdxvpazhslzbhiwzbkmznm";

        /// <summary>
        /// The encrypt test.
        /// </summary>
        [Test]
        public override void EncryptTest()
        {
            var vingenere = new Vingenere(Alphabet.English26, Keyword);
            var ciphertext = vingenere.Encrypt(Message);
            Assert.AreEqual(Ciphertext, ciphertext);
        }

        /// <summary>
        /// The decrypt test.
        /// </summary>
        [Test]
        public override void DecryptTest()
        {
            var vingenere = new Vingenere(Alphabet.English26, Keyword);
            var plaintext = vingenere.Decrypt(Ciphertext);
            var messageWithoutWhitespaces = Regex.Replace(Message, @"\s+", string.Empty);
            Assert.AreEqual(messageWithoutWhitespaces, plaintext);
        }
    }
}

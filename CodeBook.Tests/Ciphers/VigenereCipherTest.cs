// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VigenereCipherTest.cs" company="MadnessSolutions">
//   Deus
// </copyright>
// <summary>
//   The vingenere test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text.RegularExpressions;
using CodeBook.Ciphers;
using CodeBook.Languages;
using NUnit.Framework;

namespace CodeBook.Tests.Ciphers
{
    /// <summary>
    ///     The vingenere test.
    /// </summary>
    [TestFixture]
    public class VigenereCipherTest : BaseCipherTest
    {
        /// <summary>
        ///     The ciphertext.
        /// </summary>
        protected const string Ciphertext = "zpdxvpazhslzbhiwzbkmznm";

        /// <summary>
        ///     The decrypt test.
        /// </summary>
        [Test]
        public override void DecryptTest()
        {
            var vingenere = new VigenereCipher(Alphabets.English26, Keyword);
            var plaintext = vingenere.Decrypt(Ciphertext);
            var messageWithoutWhitespaces = Regex.Replace(Message, @"\s+", string.Empty);
            Assert.AreEqual(messageWithoutWhitespaces, plaintext);
        }

        /// <summary>
        ///     The encrypt test.
        /// </summary>
        [Test]
        public override void EncryptTest()
        {
            var vingenere = new VigenereCipher(Alphabets.English26, Keyword);
            var ciphertext = vingenere.Encrypt(Message);
            Assert.AreEqual(Ciphertext, ciphertext);
        }
    }
}
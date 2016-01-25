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
    using System;
    using System.Text.RegularExpressions;

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
        protected const string Ciphertext = "ilvnprrpjjkqrjnbqrplifn";

        /// <summary>
        /// The encrypt test.
        /// </summary>
        [Test]
        public override void EncryptTest()
        {
            var cipher = new KeyedCaesar(Alphabet.English26, Keyphrase);
            var ciphertext = cipher.Encrypt(Message);
            Assert.AreEqual(ciphertext, Ciphertext);
        }

        /// <summary>
        /// The decrypt test.
        /// </summary>
        [Test]
        public override void DecryptTest()
        {
            var cipher = new KeyedCaesar(Alphabet.English26, Keyphrase);
            var plaintext = cipher.Decrypt(Ciphertext);
            var noWhitespacesMessage = Regex.Replace(Message, @"\s+", string.Empty);
            Assert.AreEqual(plaintext, noWhitespacesMessage);
        }
    }
}

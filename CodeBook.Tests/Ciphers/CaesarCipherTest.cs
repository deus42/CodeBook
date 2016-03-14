// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CaesarCipherTest.cs" company="MadnessSolutions">
//   Deus
// </copyright>
// <summary>
//   Defines the CaesarCipherTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using CodeBook.Ciphers;
using CodeBook.Languages;
using NUnit.Framework;

namespace CodeBook.Tests.Ciphers
{
    /// <summary>
    ///     The CaesarCipher cipher test.
    /// </summary>
    [TestFixture]
    public class CaesarCipherTest : BaseCipherTest
    {
        /// <summary>
        ///     The ciphertext.
        /// </summary>
        protected const string Ciphertext = "inajwy ywttux yt jfxy wnilj";

        /// <summary>
        ///     The shift.
        /// </summary>
        protected const int Shift = 5;

        /// <summary>
        ///     The decrypt test.
        /// </summary>
        [Test]
        public override void DecryptTest()
        {
            var cipher = new CaesarCipher(Alphabets.English26, Shift);
            var plaintext = cipher.Decrypt(Ciphertext);
            Assert.AreEqual(Message, plaintext);
        }

        /// <summary>
        ///     The encrypt test.
        /// </summary>
        [Test]
        public override void EncryptTest()
        {
            var cipher = new CaesarCipher(Alphabets.English26, Shift);
            var ciphertext = cipher.Encrypt(Message);
            Assert.AreEqual(Ciphertext, ciphertext);
        }
    }
}
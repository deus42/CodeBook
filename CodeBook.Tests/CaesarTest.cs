// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CaesarTest.cs" company="MadnessSolutions">
//   Deus
// </copyright>
// <summary>
//   Defines the CaesarTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CodeBook.Tests
{
    using CodeBook.Ciphers;

    using NUnit.Framework;

    /// <summary>
    /// The Caesar cipher test.
    /// </summary>
    [TestFixture]
    public class CaesarTest : BaseTest
    {
        /// <summary>
        /// The ciphertext.
        /// </summary>
        protected const string Ciphertext = "inajwy ywttux yt jfxy wnilj";

        /// <summary>
        /// The shift.
        /// </summary>
        protected const int Shift = 5;

        /// <summary>
        /// The encrypt test.
        /// </summary>
        [Test]
        public override void EncryptTest()
        {
            var cipher = new Caesar(Alphabet.English26, Shift);
            var ciphertext = cipher.Encrypt(Message);
            Assert.AreEqual(Ciphertext, ciphertext);
        }

        /// <summary>
        /// The decrypt test.
        /// </summary>
        [Test]
        public override void DecryptTest()
        {
            var cipher = new Caesar(Alphabet.English26, Shift);
            var plaintext = cipher.Decrypt(Ciphertext);
            Assert.AreEqual(Message, plaintext);
        }
    }
}

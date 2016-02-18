// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseCipherTest.cs" company="MadnessSolutions">
//   Deus
// </copyright>
// <summary>
//   Defines the BaseCipherTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CodeBook.Tests.Ciphers
{
    /// <summary>
    ///     The base test.
    /// </summary>
    public abstract class BaseCipherTest
    {
        /// <summary>
        ///     The keyphrase.
        /// </summary>
        protected const string Keyphrase = "businafasol";

        /// <summary>
        ///     The keyword.
        /// </summary>
        protected const string Keyword = "white";

        /// <summary>
        ///     The message.
        /// </summary>
        protected const string Message = "divert troops to east ridge";

        /// <summary>
        ///     The encrypt test.
        /// </summary>
        public abstract void EncryptTest();

        /// <summary>
        ///     The decrypt test.
        /// </summary>
        public abstract void DecryptTest();
    }
}
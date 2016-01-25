// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseTest.cs" company="MadnessSolutions">
//   Deus
// </copyright>
// <summary>
//   Defines the BaseTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CodeBook.Tests
{
    /// <summary>
    /// The base test.
    /// </summary>
    public abstract class BaseTest
    {
        /// <summary>
        /// The keyphrase.
        /// </summary>
        protected const string Keyphrase = "businafasol";

        /// <summary>
        /// The keyword.
        /// </summary>
        protected const string Keyword = "white";

        /// <summary>
        /// The message.
        /// </summary>
        protected const string Message = "divert troops to east ridge";

        /// <summary>
        /// The encrypt test.
        /// </summary>
        public abstract void EncryptTest();

        /// <summary>
        /// The decrypt test.
        /// </summary>
        public abstract void DecryptTest();

    }
}

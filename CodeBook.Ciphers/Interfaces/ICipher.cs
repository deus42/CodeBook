// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICipher.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ICipher type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CodeBook.Ciphers.Interfaces
{
    /// <summary>
    /// The Cipher interface.
    /// </summary>
    internal interface ICipher
    {
        /// <summary>
        /// Encrypt message in plaintext
        /// </summary>
        /// <param name="plaintext">Message in plaintext</param>
        /// <returns>Ciphertext</returns>
        string Encrypt(string plaintext);

        /// <summary>
        /// Decrypt ciphertext
        /// </summary>
        /// <param name="ciphertext">Ciphertext</param>
        /// <returns>Plaintext</returns>
        string Decrypt(string ciphertext);
    }
}

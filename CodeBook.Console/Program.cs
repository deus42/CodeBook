// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="MadnessSolutions">
//   Deus
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CodeBook.Launcher
{
    using System;

    using Ciphers;

    /// <summary>
    /// The program.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        internal static void Main(string[] args)
        {
            var caesarCipher = new Caesar(Alphabet.English26, -22);
            Console.WriteLine("Please make a choice: E to encrypt, D to decrypt and X for exit");
            while (true)
            {
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                {
                    case 'e':
                        Console.WriteLine("Please enter a message to encrypt: ");
                        var message = Console.ReadLine();
                        var cipherText = caesarCipher.Encrypt(message);
                        Console.WriteLine("Ciphertext: {0}", cipherText);
                        continue;
                    case 'd':
                        Console.WriteLine("Please enter a message to decrypt: ");
                        var ciphertext = Console.ReadLine();
                        var plaintext = caesarCipher.Decrypt(ciphertext);
                        Console.WriteLine("Message: {0}", plaintext);
                        continue;
                    case 'x':
                        return;
                }
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using CodeBook.Languages;

namespace CodeBook.Cryptoanalysis
{
    /// <summary>
    /// Cryptoanalysis of famous Caesar cipher.
    /// </summary>
    public class CaesarCryptoanalysis
    {
        private readonly FitnessFunction fitnessFunction;
        private readonly ILanguage language;

        public CaesarCryptoanalysis(ILanguage language = null)
        {
            if (language == null)
            {
                this.language = new English();
            }
            this.fitnessFunction = new FitnessFunction();
        }

        /// <summary>
        /// Cryptoanalyse a ciphertext 
        /// </summary>
        /// <param name="ciphertext">Ciphertext to analyse.</param>
        /// <returns>Plaintext</returns>
        public string Process(string ciphertext)
        {
            var fitnesses = new Dictionary<int, double>();
            for (int i = 0; i < 26; i++)
            {
                var text = this.language.RotateText(ciphertext, i);
                var fitness = this.fitnessFunction.CalculateQuadgramFitness(text);
                fitnesses.Add(i, fitness);
            }
            var max = fitnesses.Values.Max();
            var maxFitness = fitnesses.First(f => f.Value == max);
            var result = this.language.RotateText(ciphertext, maxFitness.Key);

            return result;
        }

    }
}

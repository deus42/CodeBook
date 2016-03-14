using System;
using System.Collections.Generic;
using System.Linq;
using CodeBook.Languages;

namespace CodeBook.Cryptoanalysis
{
    public class KeywordCryptoanalysis
    {
        private readonly ILanguage language;
        private readonly FitnessFunction fitnessFunction;
        private readonly Dictionary<string, double> fitnesses = new Dictionary<string, double>();


        public KeywordCryptoanalysis(ILanguage language = null)
        {
            if (language == null)
            {
                this.language = new English();
            }
            this.fitnessFunction = new FitnessFunction(this.language);
        }

        public string Process(string ciphertext)
        {
            this.ciphertext = ciphertext;
            Permute(this.language.Alphabet, 0, this.language.Alphabet.Length);

            var max = this.fitnesses.Values.Max();
            var maxFitness = this.fitnesses.First(f => f.Value == max);
            var result = maxFitness.Key;
            //var result = new string(maxFitness.Key);

            return result;
        }

 
    }
}

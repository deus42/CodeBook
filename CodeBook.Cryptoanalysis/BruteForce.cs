using System;
using System.Collections.Generic;
using System.Linq;
using CodeBook.Languages;

namespace CodeBook.Cryptoanalysis
{
    /// <summary>
    /// Brute force algorithm is designed to check all possible substitutions of English or other language.
    /// All possible permutations are equal 26! = 4.0329146e+26
    /// Which actually takes insanely amount of time. 
    /// Leave it for science!
    /// </summary>
    public class BruteForce
    {
        private readonly ILanguage language;
        private readonly FitnessFunction fitnessFunction;
        private readonly Dictionary<string, double> fitnesses = new Dictionary<string, double>();
        private string ciphertext;

        public BruteForce(ILanguage language = null)
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

        private void Permute(char[] cipherAlphabet, int i, int n)
        {
            if (i == n) return;

            for (int j = i; j < n; j++)
            {
                Swap(ref cipherAlphabet[i], ref cipherAlphabet[j]);

                CalculateFitnessForCandidate(cipherAlphabet);

                Permute(cipherAlphabet, i + 1, n);
                Swap(ref cipherAlphabet[i], ref cipherAlphabet[j]); // backtrack
            }

        }

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        private void CalculateFitnessForCandidate(char[] cipherAlphabetCandidate)
        {
            var stringText = string.Empty;
            foreach (var c in this.ciphertext)
            {
                var index = Array.IndexOf(cipherAlphabetCandidate, c);
                stringText += this.language.Alphabet[index];
            }

            var fitness = this.fitnessFunction.Score(stringText);
            if (!this.fitnesses.ContainsKey(stringText))
                this.fitnesses.Add(stringText, fitness);
        }

    }


}

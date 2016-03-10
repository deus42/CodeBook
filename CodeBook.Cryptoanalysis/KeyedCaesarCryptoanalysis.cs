using System.Collections.Generic;
using System.Linq;
using CodeBook.Languages;

namespace CodeBook.Cryptoanalysis
{
    public class KeyedCaesarCryptoanalysis
    {
        private readonly ILanguage language;
        private readonly FitnessFunction fitnessFunction;
        private readonly Dictionary<string, double> fitnesses = new Dictionary<string, double>();

        public KeyedCaesarCryptoanalysis(ILanguage language = null)
        {
            if (language == null)
            {
                this.language = new English();
            }
            this.fitnessFunction = new FitnessFunction(this.language);
        }

        public string Process(string ciphertext)
        {
            Permute(ciphertext.ToCharArray(), 0, ciphertext.Length);

            var max = this.fitnesses.Values.Max();
            var maxFitness = this.fitnesses.First(f => f.Value == max);
            var result = maxFitness.Key;
            //var result = new string(maxFitness.Key);

            return result;
        }

        private void Permute(char[] text, int i, int n)
        {
            if (i == n) return;

            for (int j = i; j < n; j++)
            {
                Swap(ref text[i], ref text[j]);
                var stringText = new string(text);
                var fitness = this.fitnessFunction.Score(stringText);
                if (!this.fitnesses.ContainsKey(stringText))
                    this.fitnesses.Add(stringText, fitness);

                Permute(text, i + 1, n);
                Swap(ref text[i], ref text[j]); // backtrack
            }

        }

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }
    }
}

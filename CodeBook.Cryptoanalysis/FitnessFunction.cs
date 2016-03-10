using System;
using System.Collections.Generic;
using CodeBook.Cryptoanalysis.Properties;
using CodeBook.Languages;

namespace CodeBook.Cryptoanalysis
{
    /// <summary>
    /// Fitness function for text analysis.
    /// </summary>
    public class FitnessFunction
    {
        private readonly Dictionary<string, double> quadgrams = new Dictionary<string, double>();

        /// <summary>
        /// Creates new fitness function. 
        /// </summary>
        /// <exception cref="ArgumentException">Throws if non-English language.</exception>
        /// <param name="language">Language for measure.</param>
        public FitnessFunction(ILanguage language)
        {
            if (!(language is English))
                throw new ArgumentException(Resources.OnlyEnglishLanguageSupported, nameof(language));

            var dictionary = new Dictionary<string, int>();
            var data = Resources.english_quadgrams;
            var rows = data.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var row in rows)
            {
                var values = row.Split(' ');
                var quadgram = values[0].ToLowerInvariant(); // lowering a quadgram
                var appearences = Convert.ToInt32(values[1]);
                dictionary.Add(quadgram, appearences);
            }

            var total = dictionary.Count;
            // calculate probabilities
            foreach (var quadgram in dictionary)
            {
                var probability = (double)quadgram.Value / total * 0.01;
                this.quadgrams.Add(quadgram.Key, probability);
            }
        }

        /// <summary>
        /// Calculates fitness of a text based on quadram frequencies.
        /// </summary>
        /// <param name="text">Text to analyse.</param>
        /// <returns>Fitness score as sum of all quadgrams probabilities in Log10</returns>
        public double Score(string text)
        {
            var textInLowCase = text.ToLowerInvariant();
            // calculation
            // loop for each probability of a quadgram
            double sum = 0;
            for (int i = 0; i < textInLowCase.Length - 3; i++)
            {
                var quadgram = textInLowCase.Substring(i, 4);
                if (this.quadgrams.ContainsKey(quadgram))
                {
                    var probability = this.quadgrams[quadgram];
                    sum += Math.Log10(probability); // using log10 for more convenient numbers
                }
                else
                {
                    // floor probability for rare quadgrams
                    sum += Math.Log10(0.01 / this.quadgrams.Count);
                }
            }

            return sum;
        }

        // calculate other n-grams


    }
}

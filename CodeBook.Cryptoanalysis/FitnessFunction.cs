using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CodeBook.Cryptoanalysis
{
    public class FitnessFunction
    {

        private readonly Dictionary<string, double> quadgramsProbability = new Dictionary<string, double>();

        public FitnessFunction(string language = null)
        {
            var quadgrams = new Dictionary<string, int>();
            // Load n-gram stats from resource file into dictionary
            // Create a resource manager to retrieve resources.
            string data = Properties.Resources.english_quadgrams;
            var rows = data.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var row in rows)
            {
                var values = row.Split(' ');
                var quadgram = values[0].ToLowerInvariant(); // lowering a quadgram
                var appearences = Convert.ToInt32(values[1]);
                quadgrams.Add(quadgram, appearences);
            }

            var total = quadgrams.Count;
            // calculate probabilities
            foreach (var quadgram in quadgrams)
            {
                var probability = (double)quadgram.Value / total * 0.01;
                this.quadgramsProbability.Add(quadgram.Key, probability);
            }
        }

        /// <summary>
        /// Calculates fitness of a text based on quadram frequencies.
        /// </summary>
        /// <param name="text">Text to analyse.</param>
        /// <returns>Fitness score as sum of all quadgrams probabilities in Log10</returns>
        public double CalculateQuadgramFitness(string text)
        {
            var textInLowCase = text.ToLowerInvariant();
            // calculation
            // loop for each probability of a quadgram
            double sum = 0;
            for (int i = 0; i < textInLowCase.Length - 3; i++)
            {
                var quadgram = textInLowCase.Substring(i, 4);
                if (this.quadgramsProbability.ContainsKey(quadgram))
                {
                    var probability = this.quadgramsProbability[quadgram];
                    sum += Math.Log10(probability); // using log10 for more convenient numbers
                }
                else
                {
                    // floor probability for rare quadgrams
                    sum += Math.Log10(0.01/this.quadgramsProbability.Count);
                }
            }

            return sum;
        }

        // calculate other n-grams


    }
}

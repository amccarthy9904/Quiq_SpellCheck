using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quiq_SpellCheck
{
    class SpellCheck
    {
        /// <summary>
        /// Dictionary used to lookup words
        /// </summary>
        private Hashtable dic;

        /// <summary>
        /// Initializes and instace of the SpellCheck class
        /// </summary>
        /// <param name="dic">Dictionary that holds all words needed and whether or not they are common words</param>
        public SpellCheck(Hashtable dic)
        {
            this.dic = dic;
        }

        /// <summary>
        /// Looks up a word in the dictionary
        /// </summary>
        /// <param name="query">Word to find in the dictionary</param>
        /// <returns>True if query is contained in the dictioary, false otherwise</returns>
        public bool lookup(string query)
        {
            return this.dic.ContainsKey(query);
        }

        /// <summary>
        /// Suggests a possible spelling suggestion based on the misspelled word
        /// </summary>
        /// <param name="word">Incorrectly spelled word</param>
        /// <returns>True if a suggestion was found, False otherwise</returns>
        internal bool suggest(string word)
        {
            //holds all possible suggestions
            var suggestionList = new List<Tuple<int, string>>();

            //holds all words in dictionary
            var suggestions = dic.Keys;
            foreach (object suggestion in suggestions)
            {
                //find the Levenshtein distance between the suggestion and the original word
                int distance = levenshtein(suggestion.ToString(), word);

                //only add to list of suggestions if suggestion is less than 4 transformations away from original word
                if (distance < 4)
                {
                    suggestionList.Add(Tuple.Create(distance, suggestion.ToString()));
                }
            }

            //if any suggestions were found
            if (suggestionList.Count != 0)
            {
                //find the min distance for all suggestions
                int min = suggestionList.Min().Item1;

                //attempt to find a suggestion with the minimum distance that is also a common word
                var commonSugg = suggestionList.Find(common => common.Item1 == min && (bool)this.dic[common.Item2]);

                //if a common suggestion was found
                if (commonSugg != null)
                {
                    Console.WriteLine("SUGGESTION for " + word + " -> " + commonSugg.Item2);
                    return true;
                }
                else
                {
                    Console.WriteLine("SUGGESTION for " + word + " -> " + suggestionList.Min().Item2);
                    return true;
                }
            }

            return false;
        }

        private int levenshtein(string suggestion, string input)
        {
            //store the dimensions of the matrix
            var xLen = suggestion.Length + 1;
            var yLen = input.Length + 1;
            //create char arrays from input strings
            var suggArray = suggestion.ToCharArray();
            var inArray = input.ToCharArray();
            
            //create Levenshtein Distance matrix
            int[,] matrix = new int[xLen, yLen];

            //init first row and first column to distances from empty strings
            for (int iter = 0; iter < xLen; iter++)
            {
                matrix[iter, 0] = iter;
            }
            for (int iter = 0; iter < yLen; iter++)
            {
                matrix[0, iter] = iter;
            }

            //fill matrix with distance values
            //dont change first coluymn or first row
            for (int yIter = 1; yIter < yLen; yIter++)
            {
                for (int xIter = 1; xIter < xLen; xIter++)
                {
                    int subCost = 1;

                    //if the two chars are the same there is no substitution cost
                    if (suggArray[xIter - 1] == inArray[yIter - 1])
                    {
                        subCost = 0;
                    }
                    
                    //take 3 values from space above, the space to the left and the space above and to the left 
                    var nextVal = new int[] { matrix[xIter - 1, yIter] + 1, matrix[xIter, yIter - 1] + 1, matrix[xIter - 1, yIter - 1] + subCost };
                    
                    //insert the minimum of those values into the current spot in the matrix
                    matrix[xIter,yIter] =  nextVal.Min();
                }
            }
            //return the bottom right value in the matrix - the Levenshtein distance
            return matrix[xLen - 1, yLen - 1];
        }
    }
}

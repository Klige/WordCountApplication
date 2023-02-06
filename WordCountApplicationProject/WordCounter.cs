using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCountApplicationProject
{
    public class WordCounter
    {
        /// <summary>
        /// Counts the number of occurrences of each word in the given text.
        /// </summary>
        /// <param name="text">The text to be processed.</param>
        /// <param name="orderByDescending">Boolean value whether the counted words should be ordered.</param>
        /// <returns>A dictionary mapping each word to its number of occurrences in the text.</returns>
        /// <exception cref="ArgumentException">Thrown when the text is null or empty.</exception>
        /// <exception cref="InvalidDataException">Thrown when the text contains no valid words.</exception>
        public static Dictionary<string, int> CountWords(string text, bool orderByDescending = false)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                var ex = new ArgumentException("The text is null or empty.", nameof(text));
                ExceptionHandler.PrintMessage(ex);
                throw ex;
            }

            //Text editing pattern: everything, except a-z, apostrophe and hyphen will be removed. 
            var regExp = new Regex("[^a-z'-]");
            //Replaces all unsuitable characters between words with space characters.  
            string[] words = regExp.Replace(text.ToLower(), " ")
                //Separates words by space and removes empty strings.
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //Another possible solution is not to use Regex and
            //add more separator characters to Split(), but
            //there are too many of them and it may lead to
            //incorrect output with numbers and symbols.

            if (!words.Any())
            {
                var ex = new InvalidDataException("The text contains no valid words.");
                ExceptionHandler.PrintMessage(ex);
                throw ex;
            }

            var countedWords = words.GroupBy(word => word)
                .ToDictionary(group => group.Key, group => group.Count());

            //Another possible solution, but more complex.
            // var countedWords = new Dictionary<string, int>();
            // var countedWordsSet = new HashSet<string>();
            //
            // foreach (var word in words)
            // {
            //     if (!countedWordsSet.Add(word))
            //     {
            //         countedWords[word]++;
            //     }
            //     else
            //     {
            //         countedWords[word] = 1;
            //         countedWordsSet.Add(word);
            //     }
            // }

            if (orderByDescending)
            {
                countedWords = countedWords.OrderByDescending(pair => pair.Value)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
            }

            return countedWords;
        }

        /// <summary>
        /// Prints the given dictionary of counted words to the console.
        /// </summary>
        /// <param name="countedWords">The counted words to be printed.</param>
        /// <exception cref="ArgumentException">Thrown when the counted words dictionary is null or empty.</exception>
        public static void PrintCountedWords(Dictionary<string, int> countedWords)
        {
            if (countedWords == null || !countedWords.Any())
            {
                var ex = new ArgumentException("The counted words dictionary is null or empty.", nameof(countedWords));
                ExceptionHandler.PrintMessage(ex);
                throw ex;
            }

            Console.WriteLine("Counted words: \r");
            foreach (var countedWord in countedWords)
            {
                Console.WriteLine("{0}: {1}", countedWord.Value, countedWord.Key);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace WordCountApplicationProject
{
    public class FileOperations
    {
        /// <summary>
        /// Creates a text file with the specified file path and writes sentences to it as separate lines.
        /// </summary>
        /// <param name="textFilePath">The path of the text file to be created.</param>
        /// <param name="sentences">The array of strings that represents the lines of the text file.</param>
        public static void CreateFile(string textFilePath, string[] sentences)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(textFilePath))
                {
                    foreach (string sentence in sentences)
                    {
                        writer.WriteLine(sentence);
                    }
                }
                //Another possible solution. Simpler, but less flexible.
                // File.WriteAllLines(textFilePath, sentences);
            }
            catch (Exception ex)
            {
                ExceptionHandler.PrintMessageWithStackTrace(ex);
                throw;
            }
        }

        /// <summary>
        /// Reads the entire text file and returns its content as a string.
        /// </summary>
        /// <param name="textFilePath">The path of the text file to be read.</param>
        /// <returns>The content of the text file as a string.</returns>
        public static string ReadFile(string textFilePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(textFilePath))
                {
                    return reader.ReadToEnd();
                }
                //Another possible solution. Simpler, but less flexible.
                // return File.ReadAllText(textFilePath);
            }
            catch (Exception ex)
            {
                ExceptionHandler.PrintMessageWithStackTrace(ex);
                throw;
            }
        }

        /// <summary>
        /// Saves the counted words to the text file with the specified file path.
        /// </summary>
        /// <param name="textFilePath">The path of the text file to be saved.</param>
        /// <param name="countedWords">Dictionary of the counted words to save.</param>
        public static void SaveCountedWordsToFile(string textFilePath, Dictionary<string, int> countedWords)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(textFilePath))
                {
                    foreach (var countedWord in countedWords)
                    {
                        writer.WriteLine("{0}: {1}", countedWord.Value, countedWord.Key);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.PrintMessageWithStackTrace(ex);
                throw;
            }
        }
    }
}
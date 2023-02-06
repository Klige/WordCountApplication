using System;

namespace WordCountApplicationProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string textFilePath = "text.txt"; //The full path can be written
            string countedWordsFilePath = "countedWords.txt"; //or left as is.
            string[] sentences =
            {
                "Go do these 3 things that you do so well: code, code and... test code.", //Includes regular words, apostrophe and
                "You should go right now – don't delay, it's much-needed things!" //hyphenated words, numbers and symbols.
            };

            try
            {
                FileOperations.CreateFile(textFilePath, sentences);
                string text = FileOperations.ReadFile(textFilePath);
                var countedWords = WordCounter.CountWords(text); //Has an "Order By Descending" option.
                FileOperations.SaveCountedWordsToFile(countedWordsFilePath, countedWords);
                WordCounter.PrintCountedWords(countedWords);
            }
            catch (Exception)
            {
                Console.WriteLine("\nThe program will now be terminated.");
            }
        }
    }
}
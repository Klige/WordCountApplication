using System;

namespace WordCountApplicationProject
{
    public class ExceptionHandler
    {
        /// <summary>
        /// Prints the error message of the given exception.
        /// </summary>
        /// <param name="ex">The exception to be handled.</param>
        public static void PrintMessage(Exception ex)
        {
            Console.WriteLine("An error has occurred: {0}. {1}", ex.GetType(), ex.Message);
        }

        /// <summary>
        /// Prints the error message and the stack trace of the given exception.
        /// </summary>
        /// <param name="ex">The exception to be handled.</param>
        public static void PrintMessageWithStackTrace(Exception ex)
        {
            PrintMessage(ex);
            Console.WriteLine("\nStack trace:\n{0}", ex.StackTrace);
        }
    }
}
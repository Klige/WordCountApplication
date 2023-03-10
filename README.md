This program is a word count application that performs the following tasks:

1. Creates a text file with given file path and writes a set of sentences to it.
2. Reads the content of the text file and returns it as a string.
3. Counts the number of occurrences of each word in the text and returns it as a Dictionary.
4. Saves the counted words to a text file with a given file path.
5. Prints the counted words to the console.
The program uses four classes: 'Program.cs', 'FileOperations.cs', 'WordCounter.cs', 'ExceptionHandler.cs'.


The 'Program' class in 'Program.cs' has a main method that performs all the operations mentioned above. It declares two file paths and an array of sentences. Then they are used to create a text file using the 'CreateFile()' method of the 'FileOperations' class. The content of the text file is read using the 'ReadFile()' method of the 'FileOperations' class and stored in a string variable. The 'CountWords(' method of the 'WordCounter' class is used to count the number of occurrences of each word in the text. The counted words are then saved to a text file using the 'SaveCountedWordsToFile()' method of the 'FileOperations' class and printed to the console using the 'PrintCountedWords()' method of the 'WordCounter' class.


ExceptionHandler.cs

The 'ExceptionHandler' class provides two methods for handling exceptions. The 'PrintMessage()' method takes an exception object and prints message to the console. The 'PrintMessageWithStackTrace()' takes an exception object, uses PrintMessage method and prints message to the console.

1. The 'PrintMessage()' method takes one parameter:
'Exception ex': An exception object.
2. The 'PrintMessage()' method takes an exception object and prints message to the console. The output is in the format of "An error has occurred: {Exception type}". {Exception message}.

The 'PrintMessageWithStackTrace()' method takes one parameter:
'Exception ex': An exception object.
The 'PrintMessageWithStackTrace()' method takes an exception object, uses 'PrintMessage()' method and prints message to the console. The output is in the format of "An error has occurred: {Exception type}. {Exception message}.\nStack Trace:\n{Exception stack trace}".


FileOperations.cs

The 'FileOperations' class provides three methods for creating, reading and saving a text file with counted words. The 'CreateFile()' method takes a file path and an array of strings, writes the strings to the file and throws any exceptions that might occur. The 'ReadFile()' method takes a file path, reads the text from the file and throws any exceptions that might occur. The SaveCountedWordsToFile method takes a file path and dictionary of counted words, saves them in the file and throws any exceptions that might occur. 

1. The 'CreateFile()' method takes two parameters:
'string textFilePath': A string that represents the text file path to be created.
'string[] sentences': A string that represents the lines of the text file.
The method creates a text file with the specified file path and writes sentences to it as separate lines.

2. The 'ReadFile()' method takes one parameter:
'string textFilePath': A string that represents the text file path to be readed.
The method reads the entire text file and returns its content as a string.

3. The 'SaveCountedWordsToFile()' method takes two parameters:
'string textFilePath': A string that represents the text file path to be saved.
'Dictionary<string, int> countedWords': A dictionary that represents the counted words to be saved.
The method creates a text file with the specified file path and writes counted words to it as separate lines in the format of "{word count}: {word}".

All methods have try-catch blocks to handle any exceptions that may occur during their execution and use the ExceptionHandler.PrintMessageWithStackTrace method to print the error message and the stack trace of the exception.


WordCounter.cs

The WordCounter class provides two methods for counting and printing words. The 'CountWords()' method takes a string of text, counts the words in the text, and throws an exception if the text is null, empty or doesn't contain valid words. The 'PrintCountedWords()' method takes a dictionary of counted words, prints the words and their count to the console, and throws an exception if the dictionary is null or empty.

1. The 'CountWords()' method takes two parameters:
'string text': A string that represents the text to be processed.
'bool orderByDescending': A boolean value that specifies whether the counted words should be ordered. The default value is false.
The method first checks if the text is either null or empty and throws an ArgumentException if it is. Then, the method convert text to lowercase and removes all characters except for lowercase letters, apostrophes, and hyphens from the text using a regular expression. The method splits the modified text into separate words. After that, the method checks if the words array is empty and throws an InvalidDataException if it is. Then, the method groups the words together to count the number of occurrences of each word. The method returns a dictionary that maps each word to its number of occurrences.

2. The 'PrintCountedWords()' method takes one parameter:
'Dictionary<string, int> countedWords': A dictionary that represents the counted words to be printed.
The method first checks if the countedWords dictionary is either null or empty and throws an ArgumentException if it is. Then, the method prints the countedWords dictionary to the console. The output is in the format of {word count}: {word}.
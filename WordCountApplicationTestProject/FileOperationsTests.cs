using System;
using System.Collections.Generic;
using System.IO;
using WordCountApplicationProject;
using NUnit.Framework;

namespace WordCountApplicationTestProject
{
    [TestFixture]
    public class ProgramTests
    {
        string textFilePath = "textTest.txt";

        string invalidTextFilePath = @"Y:\textTest.txt";

        string[] sentences =
        {
            "Go do these 3 things that you do so well: code, code and... test code.",
            "You should go right now – don't delay, it's much-needed things!"
        };

        Dictionary<string, int> countedWords = new Dictionary<string, int>()
        {
            { "go", 2 },
            { "do", 2 },
            { "these", 1 },
            { "things", 2 },
            { "that", 1 },
            { "you", 2 },
            { "so", 1 },
            { "well", 1 },
            { "code", 3 },
            { "and", 1 },
            { "test", 1 },
            { "should", 1 },
            { "right", 1 },
            { "now", 1 },
            { "don't", 1 },
            { "delay", 1 },
            { "it's", 1 },
            { "much-needed", 1 }
        };

        [Test]
        public void CreateFile_WithValidArguments_CreatesFileWithContent()
        {
            // Arrange
            string[] expectedSentences = sentences; //Need this or no

            // Act
            FileOperations.CreateFile(textFilePath, sentences);
            string[] actualSentences = File.ReadAllLines(textFilePath);

            // Assert
            CollectionAssert.AreEqual(expectedSentences, actualSentences);
        }

        [Test]
        public void CreateFile_WithInvalidPath_ThrowsDirectoryNotFoundException()
        {
            // Assert
            Assert.Throws<DirectoryNotFoundException>(() => FileOperations.CreateFile(invalidTextFilePath, sentences));
        }

        [Test]
        public void CreateFile_WithNullPath_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => FileOperations.CreateFile(null, sentences));
        }

        [Test]
        public void CreateFile_WithNullSentences_ThrowsNullReferenceException()
        {
            // Assert
            Assert.Throws<NullReferenceException>(() => FileOperations.CreateFile(textFilePath, null));
        }

        //I didn't use parameterized tests because I have a bug with JetBrains Rider IDE in latest version similar to these:
        //https://youtrack.jetbrains.com/issue/RIDER-38133/Its-impossible-to-discover-unit-tests-in-some-of-your-projects
        //https://youtrack.jetbrains.com/issue/RIDER-74088/Cant-run-unit-tests-since-upgrade-to-2021.3.3
        //https://youtrack.jetbrains.com/issue/RSRP-487734/NUnit-unit-tests-TestCase-TestName-same-as-name-of-other-test

        // [TestCase(invalidTextFilePath, new[] { "Simple.", "Sentences." }, typeof(DirectoryNotFoundException),
        //     TestName = "CreateFile_WithInvalidPath_ThrowsDirectoryNotFoundException")]
        // [TestCase(null, new[] { "Simple.", "Sentences." }, typeof(ArgumentNullException),
        //     TestName = "CreateFile_WithNullPath_ThrowsArgumentNullException")]
        // [TestCase(textFilePath, null, typeof(NullReferenceException),
        //     TestName = "CreateFile_WithNullSentences_ThrowsNullReferenceException")]
        // public void CreateFile_WithInvalidInputs_ThrowsException(string textFilePath, string[] sentences,
        //     Type expectedExceptionType)
        // {
        //     // Assert
        //     Assert.Throws(expectedExceptionType, () => FileOperations.CreateFile(textFilePath, sentences));
        // }

        [Test]
        public void ReadFile_WithValidPath_ReturnsExpectedContent()
        {
            // Arrange
            string expectedText = string.Join("\r\n", sentences) + "\r\n";
            File.WriteAllLines(textFilePath, sentences);

            // Act
            string actualText = FileOperations.ReadFile(textFilePath);

            // Assert
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void ReadFile_WithInvalidPath_ThrowsDirectoryNotFoundException()
        {
            // Assert
            Assert.Throws<DirectoryNotFoundException>(() => FileOperations.ReadFile(invalidTextFilePath));
        }

        [Test]
        public void SaveCountedWordsToFile_WithValidArguments_SavesFileWithCountedWords()
        {
            // Arrange
            string expectedSavedCountedWords =
                "2: go\r\n2: do\r\n1: these\r\n2: things\r\n1: that\r\n2: you\r\n" +
                "1: so\r\n1: well\r\n3: code\r\n1: and\r\n1: test\r\n1: should\r\n" +
                "1: right\r\n1: now\r\n1: don't\r\n1: delay\r\n1: it's\r\n1: much-needed\r\n";

            // Act
            FileOperations.SaveCountedWordsToFile(textFilePath, countedWords);
            string actualSavedCountedWords = File.ReadAllText(textFilePath);

            // Assert
            CollectionAssert.AreEqual(expectedSavedCountedWords, actualSavedCountedWords);
        }

        [Test]
        public void SaveCountedWordsToFile_WithInvalidPath_ThrowsDirectoryNotFoundException()
        {
            // Assert
            Assert.Throws<DirectoryNotFoundException>(() =>
                FileOperations.SaveCountedWordsToFile(invalidTextFilePath, countedWords));
        }

        [Test]
        public void SaveCountedWordsToFile_WithNullPath_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => FileOperations.SaveCountedWordsToFile(null, countedWords));
        }

        [Test]
        public void SaveCountedWordsToFile_WithNullSentences_ThrowsNullReferenceException()
        {
            // Assert
            Assert.Throws<NullReferenceException>(() => FileOperations.SaveCountedWordsToFile(textFilePath, null));
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(textFilePath);
        }
    }
}
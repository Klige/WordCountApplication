using System;
using System.Collections.Generic;
using System.IO;
using WordCountApplicationProject;
using NUnit.Framework;

namespace WordCountApplicationTestProject
{
    [TestFixture]
    public class WordCounterTests
    {
        string textFilePath = "textTest.txt";

        string[] sentences =
        {
            "Go do these 3 things that you do so well: code, code and... test code.",
            "You should go right now – don't delay, it's much-needed things!"
        };

        [Test]
        public void CountWords_WithValidArguments_CountsWords()
        {
            // Arrange
            var expectedCountedWords = new Dictionary<string, int>()
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
            File.WriteAllLines(textFilePath, sentences);

            // Act
            var actualCountedWords = WordCounter.CountWords(string.Join("\r\n", sentences) + "\r\n");

            // Assert
            CollectionAssert.AreEqual(expectedCountedWords, actualCountedWords);
        }

        [Test]
        public void CountWords_WithValidArgumentsAndOrder_CountsWordsAndOrder()
        {
            // Arrange
            var expectedCountedWords = new Dictionary<string, int>()
            {
                { "code", 3 },
                { "go", 2 },
                { "do", 2 },
                { "things", 2 },
                { "you", 2 },
                { "these", 1 },
                { "that", 1 },
                { "so", 1 },
                { "well", 1 },
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
            File.WriteAllLines(textFilePath, sentences);

            // Act
            var actualCountedWords = WordCounter.CountWords(string.Join("\r\n", sentences) + "\r\n");

            // Assert
            CollectionAssert.AreEqual(expectedCountedWords, actualCountedWords);
        }

        [Test]
        public void CountWords_WithInvalidArgument_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => WordCounter.CountWords(""));
        }

        [Test]
        public void CountWords_WithNullArgument_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => WordCounter.CountWords(null));
        }

        [Test]
        public void CountWords_WithTextWithoutWords_ThrowsFileNotFoundException()
        {
            // Assert
            Assert.Throws<InvalidDataException>(() => WordCounter.CountWords("!!!"));
        }

        //I didn't use parameterized tests because I have a bug with JetBrains Rider IDE in latest version similar to these:
        //https://youtrack.jetbrains.com/issue/RIDER-38133/Its-impossible-to-discover-unit-tests-in-some-of-your-projects
        //https://youtrack.jetbrains.com/issue/RIDER-74088/Cant-run-unit-tests-since-upgrade-to-2021.3.3
        //https://youtrack.jetbrains.com/issue/RSRP-487734/NUnit-unit-tests-TestCase-TestName-same-as-name-of-other-test

        // [TestCase("", typeof(ArgumentException),
        //     TestName = "CountWords_WithInvalidArgument_ThrowsArgumentException")]
        // [TestCase(null, typeof(ArgumentException),
        //     TestName = "CountWords_WithNullArgument_ThrowsArgumentException")]
        // [TestCase("!!!", typeof(InvalidDataException),
        //     TestName = "CountWords_WithTextWithoutWords_ThrowsFileNotFoundException")]
        // public void CountWords_WithInvalidArguments_ThrowsException(string text, Type expectedExceptionType)
        // {
        //     //Assert
        //     Assert.Throws(expectedExceptionType, () => WordCounter.CountWords(text));
        // }

        [Test]
        public void PrintCountedWords_WithNullArgument_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => WordCounter.PrintCountedWords(null));
        }

        [Test]
        public void PrintCountedWords_WithNoElements_ThrowsArgumentException()
        {
            // Arrange
            var noElementsCountedWords = new Dictionary<string, int>();

            // Assert
            Assert.Throws<ArgumentException>(() => WordCounter.PrintCountedWords(noElementsCountedWords));
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(textFilePath);
        }
    }
}
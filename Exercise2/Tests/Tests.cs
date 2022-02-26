using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Task2.Code;

namespace Exercise2.Tests
{
    [TestFixture]
    public class Test
    {
        private static readonly string DirectoryPath =
            Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\"));

        private const string ReadingFilename = "Numbers.txt";

        [Test]
        public void TestSortNumbers()
        {
            CreateRandom.CreateNumbersFile(DirectoryPath, ReadingFilename);
            var stringFromFile = FileMethods.ReadStringFromFile(DirectoryPath, ReadingFilename);
            var stringsArray = stringFromFile.Split(' ');
            var numbersArray = new int[stringsArray.Length];
            for (var i = 0; i < numbersArray.Length; i++)
            {
                numbersArray[i] = Convert.ToInt32(stringsArray[i]);
            }

            var sortedArray = ShellSort.ShellSortNumbers(numbersArray, 0);
            var text = "";
            foreach (var i in sortedArray.Item1)
            {
                text += i + " ";
            }
            FileMethods.WriteToFile(text, DirectoryPath, "SortedNumbers.txt");

            Array.Sort(numbersArray);
            for (var i = 0; i < numbersArray.Length; i++)
            {
                Assert.AreEqual(sortedArray.Item1[i], numbersArray[i]);
            }
        }

        [Test]
        public void TestSortStrings()
        {
            CreateRandom.CreateStringsFile(DirectoryPath, "Strings.txt");
            var stringFromFile = FileMethods.ReadStringFromFile(DirectoryPath, "Strings.txt");
            var stringsArray = stringFromFile.Split(' ');
            var sortedArray = ShellSort.ShellSortStrings(stringsArray, 0);
            var text = sortedArray.Item1.Aggregate("", (current, i) => current + (i + " "));
            FileMethods.WriteToFile(text, DirectoryPath, "SortedStrings.txt");

            Array.Sort(stringsArray);
            for (var i = 0; i < stringsArray.Length; i++)
            {
                Assert.AreEqual(sortedArray.Item1[i], stringsArray[i]);
            }
        }
    }
}
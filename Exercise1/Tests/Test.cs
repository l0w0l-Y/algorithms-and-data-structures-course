using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Exercise1
{
    [TestFixture]
    internal class Tests
    {
        private static readonly string DirectoryPath =
            Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\"));

        private const string ReadingFilename = "Participants.txt";
        private const string WritingFilename = "decoding.txt";

        private const string TestString = "GIRL,\r\nBOY,\r\nBOY,\r\nGIRL,\r\nBOY";
        private static readonly string TestFileString = TestString.Replace("\r\n", "");

        private static readonly CircularLinkedList<string> TestCircularLinkedList = new CircularLinkedList<string>()
        {
            "GIRL", "BOY", "BOY", "GIRL", "BOY"
        };

        private static readonly CircularLinkedList<string> RemovedCircularLinkedList = new CircularLinkedList<string>()
        {
            "GIRL", "BOY", "GIRL", "BOY", "GIRL"
        };

        private static readonly CircularLinkedList<string> SortedCircularLinkedList = new CircularLinkedList<string>()
        {
            "BOY", "BOY", "BOY", "GIRL", "GIRL"
        };

        private static readonly CircularLinkedList<string> DeletedCircularLinkedList = new CircularLinkedList<string>()
        {
            "GIRL", "BOY", "BOY"
        };

        private static readonly string[] ParticipantsArray = TestFileString.Split(',');

        [Test]
        public void TestCoding()
        {
            var stringFromFile = Coding.ReadStringFromFile(DirectoryPath, ReadingFilename);
            Assert.AreEqual(stringFromFile, TestString);
        }

        [Test]
        public void TestCreatingList()
        {
            var circularLinkedList = Coding.CreatingList(TestFileString.Split(','));
            for (var i = 0; i < circularLinkedList.Count; i++)
                Assert.AreEqual(circularLinkedList.ElementAt(i), TestCircularLinkedList.ElementAt(i));
        }

        [Test]
        public void TestDecoding()
        {
            Decoding.WriteToFile(TestCircularLinkedList, DirectoryPath, WritingFilename);
            var circularLinkedList = Coding.CreatingList(Coding.ReadStringFromFile(DirectoryPath, WritingFilename)
                .Replace("\r\n", "").Split(','));
            for (var i = 0; i < circularLinkedList.Count; i++)
                Assert.AreEqual(circularLinkedList.ElementAt(i), TestCircularLinkedList.ElementAt(i));
        }

        [Test]
        public void TestAdding()
        {
            var circularLinkedList = new CircularLinkedList<string>();
            foreach (var participant in ParticipantsArray)
                circularLinkedList.Add(participant);
            for (var i = 0; i < circularLinkedList.Count; i++)
                Assert.AreEqual(circularLinkedList.ElementAt(i), TestCircularLinkedList.ElementAt(i));
        }

        [Test]
        public void TestRemoving()
        {
            var circularLinkedList = new CircularLinkedList<string>
            {
                ParticipantsArray,
                "GIRL"
            };
            circularLinkedList.Remove("BOY");
            for (var i = 0; i < circularLinkedList.Count; i++)
                Assert.AreEqual(RemovedCircularLinkedList.ElementAt(i), circularLinkedList.ElementAt(i));
        }

        [Test]
        public void TestMerging()
        {
            var firstList = new CircularLinkedList<string>();
            var secondList = new CircularLinkedList<string>();
            firstList.Add(new[] { "GIRL", "BOY", "BOY" });
            secondList.Add(new[] { "GIRL", "BOY" });
            var mergedList = CircularLinkedList<string>.Merge(firstList, secondList);
            for (var i = 0; i < mergedList.Count; i++)
                Assert.AreEqual(mergedList.ElementAt(i), mergedList.ElementAt(i));
        }

        [Test]
        public void TestDividingCircularListIntoTwoParts()
        {
            var list = new CircularLinkedList<string> { new[] { "BOY", "BOY", "GIRL", "BOY" } };
            var firstTestList = new CircularLinkedList<string>()
            {
                "BOY", "BOY", "BOY"
            };
            var secondTestList = new CircularLinkedList<string>()
            {
                "GIRL"
            };
            var (first, second) = CircularLinkedList<string>.DivideIntoTwoParts(list, "BOY");
            for (var i = 0; i < first.Count; i++)
                Assert.AreEqual(first.ElementAt(i), firstTestList.ElementAt(i));
            for (var i = 0; i < second.Count; i++)
                Assert.AreEqual(second.ElementAt(i), secondTestList.ElementAt(i));
        }

        [Test]
        public void TestSorting()
        {
            var sortingList = CircularLinkedList<string>.Sorting(TestCircularLinkedList, "BOY");
            for (var i = 0; i < sortingList.Count; i++)
                Assert.AreEqual(sortingList.ElementAt(i), SortedCircularLinkedList.ElementAt(i));
        }

        [Test]
        public void TestDeleting()
        {
            var deletedList = CircularLinkedList<string>.Deleting(TestCircularLinkedList, 2);
            for (var i = 0; i < deletedList.Count; i++)
                Assert.AreEqual(deletedList.ElementAt(i), DeletedCircularLinkedList.ElementAt(i));
        }
    }
}
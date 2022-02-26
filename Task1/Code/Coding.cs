using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1
{
    internal class Coding : CircularLinkedList<string>
    {
        // Reads the entire text file returns a string.
        public static string ReadStringFromFile(string directoryPath, string filename)
        {
            var path = directoryPath + $"\\{filename}";
            try
            {
                return new StreamReader(path).ReadToEnd();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Create a list of participants from a string. All participant data is separated by spaces.
        public static CircularLinkedList<string> CreatingList(IEnumerable<string> lines)
        {
            return new CircularLinkedList<string> { lines };
        }
    }
}
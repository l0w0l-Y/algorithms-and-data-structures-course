using System;
using System.IO;

namespace ConsoleApplication1
{
    internal static class Decoding
    {
        // Create a text file with members.
        public static void
            WriteToFile(CircularLinkedList<string> list, string directoryPath,
                string filename)
        {
            var path = directoryPath + $"\\{filename}";
            var text = "";
            var isFirst = false;
            foreach (var str in list)
            {
                if (!isFirst)
                {
                    text += str;
                    isFirst = true;
                }
                else text += ",\r\n" + str;
            }

            try
            {
                using (var streamWriter = new StreamWriter(path, false, System.Text.Encoding.UTF8))
                {
                    streamWriter.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
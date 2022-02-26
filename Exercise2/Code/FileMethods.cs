using System;
using System.IO;

namespace Exercise2.Code
{
    public static class FileMethods
    {
        // Reads a text file with a specific name from the given directory.
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
        
        // Create a text file with a specific name from the given directory and paste the text into the file.
        public static void WriteToFile(string text, string directoryPath,
            string filename)
        {
            var path = directoryPath + $"\\{filename}";
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
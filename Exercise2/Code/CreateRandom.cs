using System;
using System.IO;

namespace Exercise2.Code
{
    public static class CreateRandom
    {
        // Generates a random number of ints in a range.
        public static void CreateNumbersFile(string directoryPath, string filename)
        {
            var rnd = new Random();
            var randomKits = rnd.Next(50, 100);
            var path = directoryPath + $"\\{filename}";
            var text = "";
            for (var i = 0; i < randomKits; i++)
            {
                var randomCount = rnd.Next(100, 10000);
                if (i == randomKits - 1)
                    text += randomCount;
                else text += randomCount + " ";
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
        
        // Generates a random number of strings in a range.
        public static void CreateStringsFile(string directoryPath, string filename)
        {
            var rnd = new Random();
            var randomKits = rnd.Next(50, 100);
            var path = directoryPath + $"\\{filename}";
            var text = "";
            for (var i = 0; i < randomKits; i++)
            {
                string word = "";
                for (var j = 0; j < rnd.Next(2, 30); j++)
                {
                    word += (char)rnd.Next(97, 122);
                }

                if (i == randomKits - 1)
                    text += word;
                else text += word + " ";
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
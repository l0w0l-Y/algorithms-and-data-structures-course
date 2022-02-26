using System;

namespace Exercise2.Code
{
    public static class ShellSort
    {
        // Sorts an array of numbers using sort shell.
        public static (int[], int) ShellSortNumbers(int[] array, int it)
        {
            var size = array.Length;
            for (var step = size / 2; step > 0; step /= 2)
            {
                it++;
                for (var i = step; i < size; i++)
                {
                    it++;
                    for (var j = i - step; j >= 0 && array[j] > array[j + step]; j -= step)
                    {
                        (array[j], array[j + step]) = (array[j + step], array[j]);
                        it++;
                    }
                }
            }
            return (array, it);
        }
    
        // Sorts an array of strings using sort shell.
        public static (string[], int) ShellSortStrings(string[] array, int it)
        {
            var size = array.Length;
            for (var step = size / 2; step > 0; step /= 2)
            {
                it++;
                for (var i = step; i < size; i++)
                {
                    it++;
                    for (var j = i - step;
                         j >= 0 && String.CompareOrdinal(array[j], array[j + step]) > 0;
                         j -= step)
                    {
                        (array[j], array[j + step]) = (array[j + step], array[j]);
                        it++;
                    }
                }
            }

            return (array, it);
        }
    }
}
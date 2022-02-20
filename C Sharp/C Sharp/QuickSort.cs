using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public static class QuickSort
    {
        private static int Partition(int[] array, int low, int high)
        {
            int x = array[high];
            int i = low - 1;
            int swap;

            for (int j = low; j <= high - 1; j++)
            {
                if (array[j] <= x)
                {
                    i++;
                    swap = array[j];
                    array[j] = array[i];
                    array[i] = swap;
                }
            }
            swap = array[i + 1];
            array[i + 1] = array[high];
            array[high] = swap;


            return i + 1;
        }

        public static void Sort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int part = Partition(array, low, high);
                Sort(array, low, part - 1);
                Sort(array, part + 1, high);
            }
        }
    }
}


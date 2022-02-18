using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MaxHeapTree
    {

        private int Left(int index)
        {
            return index * 2;
        }

        private int Right(int index)
        {
            return index * 2 + 1;
        }

        public void MaxHeapify(int[] array, int index)
        {
            int largest = index;
            int left = Left(index);
            int right = Right(index);

            if (left <= array.Length && array[left - 1] > array[index - 1])
                largest = left;

            else
                largest = index;

            if (right <= array.Length && array[right - 1] > array[largest - 1])
                largest = right;

            if (largest != index)
            {
                int max = array[largest - 1];
                int min = array[index - 1];

                array[index - 1] = max;
                array[largest - 1] = min;

                Console.WriteLine(largest - 1);
                MaxHeapify(array, largest);
            }
        }

        public void BuildMaxHeap(int[] array)
        {
            int length = array.Length/2;
            for (int i = length; i > 0; i--)
                MaxHeapify(array, i);
        }
    }
}

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
            return index * 2 + 1;
        }

        private int Right(int index)
        {
            return index * 2 + 2;
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private void MaxHeapify(int[] array, int index, int length)
        {
            int largest = index;
            int left = Left(index);
            int right = Right(index);

            if (left <= length -1 && array[left] > array[index])
                largest = left;

            else
                largest = index;

            if (right <= length -1 && array[right] > array[largest])
                largest = right;

            if (largest != index)
            {
                int max = array[largest];
                int min = array[index];

                array[index] = max;
                array[largest] = min;

                MaxHeapify(array, largest, largest);
            }
        }

        public void BuildMaxHeap(int[] array)
        {
            int length = (array.Length - 1)/2;
            for (int i = (array.Length - 1) / 2; i > -1; i--)
                MaxHeapify(array, i, array.Length);
        }

        public void HeapSort(int[] array)
        {
            BuildMaxHeap(array);
            for (int i = array.Length - 1; i > 0; i--)
            {
                int swap = array[i];
                array[i] = array[0];
                array[0] = swap;

                MaxHeapify(array, 0, i);

                foreach (int num in array)
                    Console.Write("{0} ", num);
                Console.WriteLine();
            }
        }
    }
}

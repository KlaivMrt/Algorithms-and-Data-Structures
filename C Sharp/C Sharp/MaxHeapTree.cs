using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MaxHeapTree
    {
        private List<int> heap;

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

        private void MaxHeapify(List<int> array, int index, int length)
        {
            int largest = index;
            int left = Left(index);
            int right = Right(index);

            if (left <= length - 1 && array[left] > array[index])
                largest = left;

            else
                largest = index;

            if (right <= length - 1 && array[right] > array[largest])
                largest = right;

            if (largest != index)
            {
                int swap = array[largest];
                array[largest] = array[index];
                array[index] = swap;

                MaxHeapify(array, largest, length);
            }
        }

        public void BuildMaxHeap(int[] array)
        {
            heap = array.ToList();
            for (int i = (heap.Count() - 1) / 2; i > -1; i--)
                MaxHeapify(heap, i, heap.Count());
        }

        public void BuildMaxHeap(List<int> array)
        {
            heap = array;
            for (int i = (heap.Count() - 1) / 2; i > -1; i--)
                MaxHeapify(heap, i, heap.Count());
        }

        public void Add(int num)
        {
            heap.Add(num);
            int pos = heap.Count() - 1;
            // int length = heap.Count();
            while (pos > 0)
            {
                int parent = Parent(pos);
                if (heap[pos] > heap[parent])
                {
                    int swap = heap[pos];
                    heap[pos] = heap[parent];
                    heap[parent] = swap;

                    pos = parent;
                }
                else break;
            }
        }

        public void Delete(int index)
        {
            int swap = heap[index];
            heap[index] = heap[0];
            heap[0] = swap;

            int first = heap[0];
            heap[0] = heap[heap.Count() - 1];
            heap[heap.Count() - 1] = first;

            heap.RemoveAt(heap.Count() - 1);

            MaxHeapify(heap, 0, heap.Count());
        }

        public List<int> GetHeap()
        {
            return heap;
        }

        public void DisplayHeap()
        {
            foreach (int num in heap)
                Console.Write(num + " ");
            Console.WriteLine();
        }

        // ----------------------------------------------------------
        private void MaxHeapify(int[] array, int index, int length)
        {
            int largest = index;
            int left = Left(index);
            int right = Right(index);

            if (left <= length - 1 && array[left] > array[index])
                largest = left;

            else
                largest = index;

            if (right <= length - 1 && array[right] > array[largest])
                largest = right;

            if (largest != index)
            {
                int max = array[largest];
                int min = array[index];

                array[index] = max;
                array[largest] = min;

                MaxHeapify(array, largest, length);
            }
        }

        private void BuildMaxHeapSort(int[] array)
        {
            for (int i = (array.Length - 1) / 2; i > -1; i--)
                MaxHeapify(array, i, array.Length);
        }

        private void BuildMaxHeapSort(List<int> array)
        {
            for (int i = (array.Count() - 1) / 2; i > -1; i--)
                MaxHeapify(array, i, array.Count());
        }

        public void HeapSort(int[] array)
        {
            BuildMaxHeapSort(array);

            foreach (int num in array)
                Console.Write(num + " ");
            Console.WriteLine();

            for (int i = array.Length - 1; i > 0; i--)
            {
                int swap = array[i];
                array[i] = array[0];
                array[0] = swap;

                MaxHeapify(array, 0, i);
            }
        }

        public void HeapSort(List<int> array)
        {
            BuildMaxHeapSort(array);

            foreach (int num in array)
                Console.Write(num + " ");
            Console.WriteLine();

            for (int i = array.Count - 1; i > 0; i--)
            {
                int swap = array[i];
                array[i] = array[0];
                array[0] = swap;

                MaxHeapify(array, 0, i);
            }
        }
    }
}

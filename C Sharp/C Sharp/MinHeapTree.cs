using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    internal class MinHeapTree
    {
        private List<int> Heap;

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

        public List<int> GetHeap()
        {
            return Heap;
        }

        public void DisplayHeap()
        {
            foreach (int num in Heap)
                Console.Write(num + " ");
            Console.WriteLine();
        }

        private void MinHeapify(List<int> array, int index, int length)
        {
            int smallest = index;
            int left = Left(index);
            int right = Right(index);

            if (left <= length - 1 && array[left] < array[index])
                smallest = left;

            else
                smallest = index;

            if (right <= length - 1 && array[right] < array[smallest])
                smallest = right;

            if (smallest != index)
            {
                int swap = array[smallest];
                array[smallest] = array[index];
                array[index] = swap;

                MinHeapify(array, smallest, length);
            }
        }

        private void MinHeapify(int[] array, int index, int length)
        {
            int smallest = index;
            int left = Left(index);
            int right = Right(index);

            if (left <= length - 1 && array[left] < array[index])
                smallest = left;

            else
                smallest = index;

            if (right <= length - 1 && array[right] < array[smallest])
                smallest = right;

            if (smallest != index)
            {
                int swap = array[smallest];
                array[smallest] = array[index];
                array[index] = swap;

                MinHeapify(array, smallest, length);
            }
        }

        public void BuildMinHeap(int[] array)
        {
            Heap = array.ToList();
            for (int i = (Heap.Count() - 1) / 2; i > -1; i--)
                MinHeapify(Heap, i, Heap.Count());
        }

        public void BuildMinHeap(List<int> array)
        {
            Heap = array;
            for (int i = (Heap.Count() - 1) / 2; i > -1; i--)
                MinHeapify(Heap, i, Heap.Count());
        }

        public void Add(int num)
        {
            Heap.Add(num);
            int pos = Heap.Count() - 1;
            // int length = heap.Count();
            while (pos > 0)
            {
                int parent = Parent(pos);
                if (Heap[pos] < Heap[parent])
                {
                    int swap = Heap[pos];
                    Heap[pos] = Heap[parent];
                    Heap[parent] = swap;

                    pos = parent;
                }
                else break;
            }
        }

        public void Delete(int index)
        {
            int swap = Heap[index];
            Heap[index] = Heap[0];
            Heap[0] = swap;

            int first = Heap[0];
            Heap[0] = Heap[Heap.Count() - 1];
            Heap[Heap.Count() - 1] = first;

            Heap.RemoveAt(Heap.Count() - 1);

            MinHeapify(Heap, 0, Heap.Count());
        }

        // ----------------------------------------------------------

        public void BuildMinHeapSort(int[] array)
        {
            Heap = array.ToList();
            for (int i = (Heap.Count() - 1) / 2; i > -1; i--)
                MinHeapify(Heap, i, Heap.Count());
        }

        public void BuildMinHeapSort(List<int> array)
        {
            Heap = array;
            for (int i = (Heap.Count() - 1) / 2; i > -1; i--)
                MinHeapify(Heap, i, Heap.Count());
        }

        public void HeapSort(int[] array)
        {
            BuildMinHeapSort(array);


            for (int i = array.Length - 1; i > 0; i--)
            {
                int swap = array[i];
                array[i] = array[0];
                array[0] = swap;

                MinHeapify(array, 0, i);
            }
        }

        public void HeapSort(List<int> array)
        {
            BuildMinHeapSort(array);


            for (int i = array.Count - 1; i > 0; i--)
            {
                int swap = array[i];
                array[i] = array[0];
                array[0] = swap;

                MinHeapify(array, 0, i);
            }
        }
    }
}

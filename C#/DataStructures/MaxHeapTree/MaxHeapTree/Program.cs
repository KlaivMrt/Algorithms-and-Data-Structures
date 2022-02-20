namespace DataStructures
{
    

    public class Program
    {

        public static int[] changes(int[] array)
        {
            int max = array[0];
            int min = array[1];

            array[1] = max;
            array[0] = min;

            return array;
        }
        public static void Main(string[] args)
        {
            int[] array = new int[] { 2, 7, 26, 25, 19, 17, 1, 90, 3, 36 };
            List<int> list = new List<int>() { 16, 4, 10, 14, 7, 9, 3, 2, 8, 1 };


            MaxHeapTree tree = new MaxHeapTree();
            tree.BuildMaxHeap(array);
            tree.DisplayHeap();
            Console.WriteLine();

            tree.BuildMaxHeap(list);
            tree.DisplayHeap();
            Console.WriteLine();

            tree.HeapSort(array);
            foreach (int num in array)
                Console.Write(num + " ");
            Console.WriteLine();
            Console.WriteLine();

            tree.HeapSort(list);
            foreach (int num in list)
                Console.Write(num + " ");
            Console.WriteLine();
        }
    }
}
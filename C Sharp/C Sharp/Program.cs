namespace C_Sharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[] { 10, 3, 1, 7, 8, 9, 2};
            MinHeapTree minHeapTree = new MinHeapTree();

            minHeapTree.BuildMinHeap(array);
            minHeapTree.DisplayHeap();

            minHeapTree.Delete(0);
            minHeapTree.DisplayHeap();
        }
    }
}
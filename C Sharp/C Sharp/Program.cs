namespace C_Sharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[] { 8, 7, 5, 6 };
            QuickSort.Sort(array, 0, array.Length - 1);

            foreach(int num in array)
                Console.Write(num + " ");
            Console.WriteLine();
        }
    }
}
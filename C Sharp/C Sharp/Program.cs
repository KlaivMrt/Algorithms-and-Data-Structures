namespace C_Sharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int x = 12;
            int y = 43;
            int z = 300;
            object one = new object();

            LinkedList_ lk = new LinkedList_();

            lk.Add(x);
            lk.Add(y);
            lk.Add(z);
            lk.Add(one);
            lk.Add(400);
            lk.Add(15);
            lk.Add(26);

            lk.Display();

            /* lk.Append(2, 1000);
             lk.Display();*/

            lk.DeleteNode(0);
            lk.Display();

            lk.DeleteNode(1);
            lk.Display();

            lk.DeleteNode(2);
            lk.Display();

            lk.DeleteNode(3);
            lk.Display();
        }
    }
}
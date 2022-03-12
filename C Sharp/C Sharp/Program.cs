namespace C_Sharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            Random random = new Random();

            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                BT_Node node = new BT_Node();
                node.Key = i + rnd.Next(1, 500);
                tree.TreeInsert(node);
            }

            tree.InorderTreeWalk(tree.Root);

        }
    }
}
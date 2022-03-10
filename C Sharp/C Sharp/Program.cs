namespace C_Sharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            Random random = new Random();

            BT_Node? three = null;
            BT_Node? two = null;

            for (int i = 0; i < 10; i++)
            {
                BT_Node node = new BT_Node();
                if (i == 3)
                {
                    node.Key = i;
                    three = node;
                    tree.TreeInsert(three);
                }
                else if (i == 2)
                {
                    node.Key = i;
                    two = node;
                    tree.TreeInsert(two);
                }
                else
                {
                    node.Key = i;
                    tree.TreeInsert(node);
                }

            }

            tree.InorderTreeWalk(tree.Root);

            tree.TreeDelete(three);
            Console.WriteLine();

            tree.InorderTreeWalk(tree.Root);
        }
    }
}
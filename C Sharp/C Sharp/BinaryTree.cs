using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class BT_Node
    {
        public int Key { get; set; }
        public BT_Node? Parent { get; set; }
        public BT_Node? Left { get; set; }
        public BT_Node? Right { get; set; }
    }

    public class BinaryTree
    {
        public BT_Node? Root { get; set; }

        public void InorderTreeWalk(BT_Node node)
        {
            if (node != null)
            {
                InorderTreeWalk(node.Left);
                Console.Write(node.Key + " ");
                InorderTreeWalk(node.Right);
            }
        }

        public BT_Node RecursiveTreeSearch(BT_Node node, int key)
        {
            if (node == null || key == node.Key)
            {
                return node;
            }
            if (key < node.Key)
            {
                return RecursiveTreeSearch(node.Left, key);
            }
            else
            {
                return RecursiveTreeSearch(node.Right, key);
            }
        }

        public BT_Node IterativeTreeSearch(BT_Node node, int key)
        {
            BT_Node currentNode = node;
            while (currentNode != null && key != currentNode.Key)
            {
                if (key < node.Key)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            return currentNode;
        }

        public BT_Node TreeMinimum(BT_Node node)
        {
            BT_Node currentNode = node;
            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }
            return currentNode;
        }

        public BT_Node TreeMaximum(BT_Node node)
        {
            BT_Node currentNode = node;
            while (currentNode.Right != null)
            {
                currentNode = currentNode.Right;
            }
            return currentNode;
        }

        public void TreeInsert(BT_Node node)
        {
            BT_Node? y = null;
            BT_Node? x = Root;

            while (x != null)
            {
                y = x;

                if (node.Key < x.Key)
                {
                    x = x.Left;
                }
                else
                {
                    x = x.Right;
                }
            }

            node.Parent = y;

            if (y == null)
            {
                Root = node;
            }
            else if (node.Key < y.Key)
            {
                y.Left = node;
            }
            else
            {
                y.Right = node;
            }
        }

        private void Transplant(BT_Node u, BT_Node v)
        {
            if (u.Parent == null)
            {
                Root = v;
            }
            else if (u == u.Parent.Left)
            {
                u.Parent.Left = v;
            }
            else
            {
                u.Parent.Right = v;
            }
            if (v != null)
            {
                v.Parent = u.Parent;
            }
        }

        public void TreeDelete(BT_Node node)
        {
            if (node.Left == null)
            {
                Transplant(node, node.Right);
            }
            else if (node.Right == null)
            {
                Transplant(node, node.Left);
            }
            else
            {
                BT_Node successor = TreeMinimum(node.Right);
                if (successor.Parent != node)
                {
                    Transplant(successor, successor.Right);
                    successor.Right = node.Right;
                    successor.Right.Parent = successor;
                }
                Transplant(node, successor);
                successor.Left = node.Left;
                successor.Left.Parent = successor;
            }
        }
    }
}

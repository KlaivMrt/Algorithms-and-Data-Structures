using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class LL_Node
    {
        private LL_Node? Next;
        private LL_Node? Previous;

        private readonly int numContent;
        private readonly object? obContent;

        internal LL_Node(int content)
        {
            numContent = content;
        }

        internal LL_Node(object content)
        {
            obContent = content;
        }

        internal void SetNext(LL_Node next)
        {
            Next = next;
        }

        internal void SetPrevious(LL_Node previous)
        {
            Previous = previous;
        }

        internal LL_Node GetNext()
        {
            return Next;
        }

        internal LL_Node GetPrevious()
        {
            return Previous;
        }

        internal void RemoveNext()
        {
            Next = null;
        }

        internal void RemovePrevious()
        {
            Previous = null;
        }

        public override string ToString()
        {
            return obContent != null ? obContent.ToString() : numContent.ToString();
        }
    }

    public class LinkedList_
    {
        private LL_Node? First;
        private LL_Node? Last;
        private int length = 0;

        public void Add(int content)
        {
            LL_Node node = new LL_Node(content);

            if (Last != null)
            {
                Last.SetNext(node);
                node.SetPrevious(Last);
                Last = node;
            }
            else if (First != null && Last == null)
            {
                First.SetNext(node);
                Last = node;
                Last.SetPrevious(First);
            }
            else if (First == null && Last == null)
            {
                First = node;
            }
            length++;
        }

        public void Add(object content)
        {
            LL_Node node = new LL_Node(content);

            if (Last != null)
            {
                Last.SetNext(node);
                node.SetPrevious(Last);
                Last = node;
            }
            else if (First != null && Last == null)
            {
                First.SetNext(node);
                Last = node;
                Last.SetPrevious(First);
            }
            else if (First == null && Last == null)
            {
                First = node;
            }
            length++;
        }

        public void DeleteNode(int index)
        {
            LL_Node? current = this.First;
            LL_Node? next;

            if (index > length - 1 || index < 0)
            {
                Console.WriteLine("ok");
                throw new IndexOutOfRangeException("The index provided is out of the linked list's range");
            }

            if (index == 0 && length == 1)
            {
                First = null;
                length--;
                return;

            }
            else if (index == 0 && length > 1)
            {
                First = current.GetNext();
                current.RemoveNext();
                First.RemovePrevious();
                length--;
                return;
            }

            if (index == length - 1)
            {
                //Console.WriteLine("ok");
                current = Last;
                next = current.GetPrevious();
                next.RemoveNext();
                current.RemovePrevious();
                if (next == First)
                {
                    Last = null;
                }
                else
                {
                    Last = next;
                }
                length--;
                return;
            }

            int count = 0;
            while (count < index)
            {
                count++;
                next = current.GetNext();
                current = next;
            }

            next = current.GetNext();
            next.SetPrevious(current.GetPrevious());
            current.RemoveNext();
            current.RemovePrevious();
            next.GetPrevious().SetNext(next);
            length--;

        }


        public void Append(int index, int content)
        {
            LL_Node newNode = new LL_Node(content);
            LL_Node? current = this.First;
            LL_Node? next;

            if (length == 0)
            {
                throw new Exception("Linked list is empty, consider adding first to it");
            }

            if (index == 0)
            {
                newNode.SetNext(First);
                First.SetPrevious(newNode);
                First = newNode;
                length++;
                return;
            }

            if (index > length - 1 && Last != null)
            {
                Last.SetNext(newNode);
                newNode.SetPrevious(Last);
                Last = newNode;
                length++;
                return;
            }

            int count = 0;
            while (count < index)
            {
                count++;
                next = current.GetNext();
                current = next;
            }

            newNode.SetPrevious(current.GetPrevious());
            current.GetPrevious().SetNext(newNode);
            current.SetPrevious(newNode);
            newNode.SetNext(current);
            length++;
        }

        public void Append(int index, object content)
        {
            LL_Node newNode = new LL_Node(content);
            LL_Node? current = this.First;
            LL_Node? next;

            if (length == 0)
            {
                throw new Exception("Linked list is empty");
            }

            if (index == 0)
            {
                newNode.SetNext(First);
                First.SetPrevious(newNode);
                First = newNode;
                length++;
                return;
            }

            if (index > length - 1 && Last != null)
            {
                Last.SetNext(newNode);
                newNode.SetPrevious(Last);
                Last = newNode;
                length++;
                return;
            }

            int count = 0;
            while (count < index)
            {
                count++;
                next = current.GetNext();
                current = next;
            }

            newNode.SetPrevious(current.GetPrevious());
            current.GetPrevious().SetNext(newNode);
            current.SetPrevious(newNode);
            newNode.SetNext(current);
            length++;
        }

        public void Display()
        {
            LL_Node? current = this.First;
            int count = 0;
            while (count < length)
            {
                Console.Write(current + " <-> ");
                current = current.GetNext();
                count++;
            }
            Console.WriteLine("null -- Length: " + length);
            Console.WriteLine();
        }
    }
}

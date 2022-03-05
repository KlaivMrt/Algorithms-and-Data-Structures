using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class Node
    {
        private Node? Next;
        private Node? Previous;

        private readonly int numContent;
        private readonly object? obContent;

        internal Node(int content)
        {
            numContent = content;
        }

        internal Node(object content)
        {
            obContent = content;
        }

        internal void SetNext(Node next)
        {
            Next = next;
        }

        internal void SetPrevious(Node previous)
        {
            Previous = previous;
        }

        internal Node GetNext()
        {
            return Next;
        }

        internal Node GetPrevious()
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
        private Node? First;
        private Node? Last;
        private int length = 0;

        public void Add(int content)
        {
            Node node = new Node(content);

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
            Node node = new Node(content);

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
            Node? current = this.First;
            Node? next;

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
            Node newNode = new Node(content);
            Node? current = this.First;
            Node? next;

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
            Node newNode = new Node(content);
            Node? current = this.First;
            Node? next;

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
            Node? current = this.First;
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

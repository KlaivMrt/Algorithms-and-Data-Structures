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
    }
}

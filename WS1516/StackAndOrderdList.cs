using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace WS1516
{
    public class StackAndOrderdList<T> where T : IComparable
    {
        // a)
        private class Node : IComparable
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T newData)
            {
                Data = newData;
            }

            public int CompareTo(object obj)
            {
                return Data.CompareTo(((Node) obj).Data);
            }
        }

        private Node firstOfStack;
        private Node firstOfOrderedList;

        public void Add(T toAdd)
        {
            AddToStack(toAdd);
            AddToOrderedList(toAdd);
        }

        private void AddToStack(T toAdd)
        {
            Node newNode = new Node(toAdd);
            newNode.Next = firstOfStack;
            firstOfStack = newNode;
        }
        
        /// <summary>
        /// neuer Eintrag soll jeweils hinter die Elemente einsortiert
        /// werden, die kleiner als der neue Eintrag sind
        /// </summary>
        /// <param name="toAdd">Data to add to the sorted list</param>
        private void AddToOrderedList(T toAdd)
        {
            Node newNode = new Node(toAdd);

            if (firstOfOrderedList == null)
            {
                firstOfOrderedList = newNode;
                return;
            }
            if (firstOfOrderedList.CompareTo(newNode) != -1)
            {
                // wenn Listenanfang nicht kleiner als neues Element
                // dann 1. neuesElement 2. alter ListenAnfang
                newNode.Next = firstOfOrderedList;
                firstOfOrderedList = newNode;
                return;
            }

            Node pointer = firstOfOrderedList;
            while (pointer.Next != null)
            {
                if (pointer.Next.CompareTo(newNode) != -1)
                {
                    newNode.Next = pointer.Next;
                    pointer.Next = newNode;
                    return;
                }
                pointer = pointer.Next;
            }
            // pointer = Ende der Liste, kleiner als newNode
            pointer.Next = newNode;
        }

        public T this[int i]
        {
            get
            {
                int j = 0;
                Node pointer = firstOfStack;
                while (pointer != null)
                {
                    if (i == j)
                    {
                        return pointer.Data;
                    }
                    j++;
                    pointer = pointer.Next;
                }
                throw new IndexOutOfRangeException();
            }
        }

        public IEnumerable GetStackEnumerator()
        {
            return GetEnumeratorWithStartingPoint(firstOfStack);
        }

        public IEnumerable GetSortedEnumerator()
        {
            return GetEnumeratorWithStartingPoint(firstOfOrderedList);
        }
        
        private IEnumerable GetEnumeratorWithStartingPoint(Node pointer)
        {
            while (pointer != null)
            {
                yield return pointer.Data;
                pointer = pointer.Next;
            }
        }
    }
}
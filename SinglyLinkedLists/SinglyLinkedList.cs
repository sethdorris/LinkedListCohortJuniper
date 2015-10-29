using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode firstNode;
        private int size;

        public SinglyLinkedList()
        {
            this.firstNode = null;
            this.size = 0;
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {

        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public object this[int i]
        {
            get { return this.IndexGet(i); }
            set { throw new NotImplementedException(); }
        }

        public object IndexGet(int i)
        {
            if (i < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            SinglyLinkedListNode node1 = this.firstNode;

            for (int j = 0; j < this.size; j++)
            {
                node1 = node1.Next;
            }

            return node1.Value;
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            throw new NotImplementedException();
        }

        public void AddLast(string value)
        {
            if (firstNode == null)
            {
                firstNode = new SinglyLinkedListNode(value);
                this.size += 1;
            } else
            {
                SinglyLinkedListNode current = this.firstNode;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new SinglyLinkedListNode(value);
                this.size += 1;
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            return this.size;
        }

        public string ElementAt(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index > this.size)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (this.firstNode == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                SinglyLinkedListNode currentNode = firstNode;
                for (int j = 0; j < index; j++)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode.Value;  
            }
        }

        public string First()
        {
            if (firstNode == null)
            {
                return null;
            }
            else
            {
                return firstNode.Value;
            }
        }

        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            throw new NotImplementedException();
        }

        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            throw new NotImplementedException();
        }
    }
}

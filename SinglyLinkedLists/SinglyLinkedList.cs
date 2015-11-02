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
            get { return this.GetNodeAtThisIndex(i); }
            set { throw new NotImplementedException(); }
        }

        public object GetNodeAtThisIndex(int i)
        {
            if (i < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            SinglyLinkedListNode node1 = this.firstNode;

            for (int j = 0; j <= this.size; j++)
            {
                if (node1.Next != null)
                {
                    node1 = node1.Next;
                }     
            }

            return node1;
        }

        public void AddAfter(string existingValue, string value)
        {
            if (firstNode == null)
            {
                throw new ArgumentException("Cannot be called on an empty list");
            }
            if (!NodeNameExists(existingValue))
            {
                throw new ArgumentException("Not in the list");
            }

            SinglyLinkedListNode currentNode = firstNode;
            while (currentNode.Value != existingValue)
            {
                currentNode = currentNode.Next;
            }

            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            size += 1;
            newNode.Next = currentNode.Next;
            currentNode.Next = newNode;
        }

        public bool NodeNameExists(string value)
        {
            bool exists = false;
            if (firstNode != null)
            {
                SinglyLinkedListNode currentNode = firstNode;
                for (int i = 0; i < size; i++)
                {
                    if (currentNode.Value == value)
                    {
                        exists = true;
                    }
                    currentNode = currentNode.Next;
                }
            }
            return exists;
        }

        public void AddFirst(string value)
        {
            if (this.firstNode == null)
            {
                this.firstNode = new SinglyLinkedListNode(value);
                size += 1;
            }
            else
            {
                SinglyLinkedListNode newNextNode = firstNode;
                firstNode = new SinglyLinkedListNode(value);
                size += 1;
                firstNode.Next = newNextNode;
            }
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
            return 0;
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
            if (this.size == 0)
            {
                return null;
            }
            else
            {
              return ElementAt(size-1);
            }
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
            string[] listArray = new string[] { };
            List<string> listofNodes = new List<string> { };
            if (this.firstNode == null)
            {
                return listArray;
            }
            else
            {
                SinglyLinkedListNode currentNode = firstNode;
                for (int i = 0; i < size; i++)
                {
                    listofNodes.Add(currentNode.Value);
                    if (currentNode.Next != null)
                    {
                        currentNode = currentNode.Next;
                    }
                }
                listArray = listofNodes.ToArray();
                return listArray;
            }
        }

        public override string ToString()
        {
            if (firstNode == null)
            {
                return "{ }";
            }
            if (size == 1)
            {
                return "{ \"" + firstNode.Value.ToString() + "\" " + "}";
            }
            else
            {
                string NodesInAString = "{ ";
                SinglyLinkedListNode currentNode = firstNode;

                while(currentNode.Next != null)
                {
                    NodesInAString += "\"" + currentNode.Value.ToString() + "\", ";
                    currentNode = currentNode.Next;
                }
                NodesInAString += "\"" + currentNode.Value.ToString() + "\" }";
                return NodesInAString;
            }
        }
    }
}

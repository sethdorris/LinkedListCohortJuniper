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
            for (int i = 0; i < values.Length; i++)
            {
                AddLast(values[i].ToString());
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return ElementAt(i); }
            set {
                NodeAt(i).Value = value;
            }
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
            if (firstNode == null)
            {
                firstNode = new SinglyLinkedListNode(value);
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
                size += 1;
            } else
            {
                SinglyLinkedListNode current = this.firstNode;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new SinglyLinkedListNode(value);
                size += 1;
            }
        }

        public int Count()
        {
            return size;
        }

        public SinglyLinkedListNode NodeAt(int index)
        {
            if (index < 0)
            {
                SinglyLinkedListNode currentNode = firstNode;
                int count = 1;
                while (!currentNode.IsLast())
                {
                    count++;
                    currentNode = currentNode.Next;
                }
                return NodeAt(count + index);
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
                return currentNode;
            }
        }

        public string ElementAt(int index)
        {
            return NodeAt(index).Value;
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
            int index = 0;
            if (firstNode == null)
            {
                index = -1;
            }
            if (NodeNameExists(value))
            {
                SinglyLinkedListNode currentNode = firstNode;
                while (currentNode.Value != value)
                {
                    currentNode = currentNode.Next;
                    index += 1;
                }
            } else
            {
                index = -1;
            }
            
            return index;
        }

        public bool IsSorted()
        {
            if (firstNode == null || size <= 1) 
            {
                return true;
            }

            SinglyLinkedListNode left = firstNode;
            SinglyLinkedListNode right = firstNode.Next;

            while(right != null)
            {
                if (left > right)
                {
                    return false;
                }

                left = right;
                right = left.Next;
            }
            return true;
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
            int position = IndexOf(value);
            if (position == 0)
            {
                firstNode = firstNode.Next;
                size -= 1;
            } else if (position >= 1)
            {
                NodeAt(position - 1).Next = NodeAt(position + 1);
                size -= 1;
            }
        }

        public void Sort()
        {
            if (firstNode == null || size <= 1)
            {
                return;
            }
            SinglyLinkedListNode previous = null;
            SinglyLinkedListNode current = firstNode;
            SinglyLinkedListNode next = firstNode.Next;
            bool swap = false;
            while (next != null)
            {
                if (current > next)
                {
                    swapWithNext(previous, current);
                    swap = true;
                }
                previous = current;
                current = next;
                next = current.Next;
            }
            if (swap)
            {
                Sort();
            } 
        }

        private void swapWithNext(SinglyLinkedListNode previous, SinglyLinkedListNode swapee)
        {
            SinglyLinkedListNode swapWith = swapee.Next;
            if (previous == null)
            {
                firstNode = swapWith;
            } else
            {
                previous.Next = swapWith;           
            }  
                swapee.Next = swapWith.Next;
                swapWith.Next = swapee;
        }

        public string[] ToArray()
        {
            string[] listArray = new string[] { };
            List<string> listofNodes = new List<string> { };
            if (firstNode == null)
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
                return "{ \"" + firstNode.Value + "\" " + "}";
            }
            else
            {
                string NodesInAString = "{ ";
                SinglyLinkedListNode currentNode = firstNode;

                while(currentNode.Next != null)
                {
                    NodesInAString += "\"" + currentNode.Value + "\", ";
                    currentNode = currentNode.Next;
                }
                NodesInAString += "\"" + currentNode.Value.ToString() + "\" }";
                return NodesInAString;
            }
        }
    }
}

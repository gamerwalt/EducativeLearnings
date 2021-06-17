using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
        }
    }

    public class LinkedList
    {
        private Node Head;
        private Node Tail;
        private int Count;

        //O(1)
        public void AddFirst(int item)
        {
            var node = new Node(item);
            
            if (IsEmpty())
            {
                Head = node;
                Tail = node;
            }
            else
            {
                var temp = Head;
                Head = node;
                Head.next = temp;
            }

            Count++;
        }

        //O(1)/O(N)
        public void AddLast(int item)
        {
            var node = new Node(item);

            if (IsEmpty())
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.next = node;
                Tail = node;
            }

            Count++;
        }

        private bool IsEmpty()
        {
            return Head == null;
        }

        //O(1)
        public void DeleteFirst()
        {
            if (IsEmpty()) return;

            var nextNode = Head.next;
            Head = null;
            Head = nextNode;

            Count--;
        }

        //O(N)
        public void DeleteLast()
        {
            if (IsEmpty()) return;

            if(Head == Tail)
            {
                Head = Tail = null;
            }
            else
            {
                var previous = GetPrevious(Tail);

                previous.next = null;
                Tail = previous;
            }            

            Count--;
        }

        public Node GetPrevious(Node node)
        {
            var current = Head;
            while(current != null)
            {
                if (current.next == node) return current;
                current = current.next;
            }

            return null;
        }

        //O(N)
        public bool Contains(int item)
        {
            return IndexOf(item) != -1;
        }

        //O(N)
        public int IndexOf(int item)
        {
            var current = Head;
            var counter = 0;

            while (current != null)
            {
                if (current.value == item)
                {
                    return counter;
                }

                current = current.next;
                counter++;
            }

            return -1;
        }

        //O(1)
        public int Size()
        {
            return Count;
        }

        //O(N)
        public int[] ToArray()
        {
            var items = new int[Count];

            var current = Head;
            var index = 0;
            while(current != null)
            {
                items[index] = current.value;
                current = current.next;
                index++;
                
            }

            return items;
        }

        //O(N)
        public void Reverse()
        {
            if (IsEmpty()) throw new Exception("Linked list is empty.");

            var current = Head.next;
            var previous = Head;

            while(current != null)
            {
                var temp = current.next;

                current.next = previous;
                previous = current;
                
                current = temp;
            }

            Tail = Head;
            Tail.next = null;
            Head = previous;
        }

        //O(N)
        public int FindKthNodeFromEnd(int k)
        {
            if (k == 1) return Tail.value;
            if (k == 0 || k > Count) throw new ArgumentException("Invalid Kth node");

            var fast = Head;
            var slow = Head;
            var counter = k;

            while(fast != null)
            {
                if (counter > 0)
                {
                    counter--;
                    fast = fast.next;
                }
                else
                {
                    fast = fast.next;
                    slow = slow.next;
                }
            }

            return slow.value;
        }

        public void RemoveNthNodeFromEndOfList(int n)
        {
            if(n == 1)
            {
                var previous = this.GetPrevious(Tail);
                Tail = previous;
            }

            if (n == 0 || n > Count) throw new ArgumentException("Invalid Nth Node");

            var fast = Head;
            var slow = Head;
            var counter = n;

            while(fast != null)
            {
                if(counter > 0)
                {
                    counter--;
                    fast = fast.next;
                }
                else
                {
                    fast = fast.next;
                    slow = slow.next;
                }
            }

            //at this point, slow is at the nth node
            var previousNthNode = GetPrevious(slow);
            var next = slow.next;
            previousNthNode.next = next;
            slow = null;
            Count--;
        }

        public Node Partition(LinkedList list, int x)
        {
            var greaterThanX = new LinkedList().Head;
            var greaterRunner = greaterThanX;
            var lessThanX = new LinkedList().Head;
            var lessRunner = lessThanX;
            
            var headOfList = list.Head;

            while(headOfList != null)
            {
                if(headOfList.value < x)
                {
                    lessRunner.next = headOfList;
                    lessRunner = lessRunner.next;
                }
                else
                {
                    greaterRunner.next = headOfList;
                    greaterRunner = greaterRunner.next;
                }

                headOfList = headOfList.next;
            }

            greaterRunner.next = null;
            lessRunner.next = greaterThanX.next;
            return lessThanX;
        }
    }
}

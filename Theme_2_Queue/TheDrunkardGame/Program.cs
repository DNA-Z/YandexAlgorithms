using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TheDrunkardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Game());                        
        }

        static string Game()
        {
            int[] inputFirst = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            int[] inputSecond = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            Deque<int> first = new Deque<int>();
            Deque<int> second = new Deque<int>();

            for (int i = 0; i < inputFirst.Length; i++)
            {
                first.AddLast(inputFirst[i]);
                second.AddLast(inputSecond[i]);
            }

            int moveCount = 0;
            while (moveCount < 1000000 - inputFirst.Length)
            {
                if(first.Count > 0 && second.Count > 0)
                {
                    if(first.First == 0 && second.First == 9)
                    {
                        first.AddLast(first.DequeueFirst());
                        first.AddLast(second.DequeueFirst());
                    }                        
                    else if (first.First == 9 && second.First == 0)
                    {
                        second.AddLast(first.DequeueFirst());
                        second.AddLast(second.DequeueFirst());
                    }
                    else
                    {
                        if (first.First > second.First)
                        {
                            first.AddLast(first.DequeueFirst());
                            first.AddLast(second.DequeueFirst());
                        }
                        else
                        {
                            second.AddLast(first.DequeueFirst());
                            second.AddLast(second.DequeueFirst());
                        }
                    }                    
                }
                else
                {
                    if(first.Count == 0)
                    {
                        return "second " + moveCount.ToString();
                    }
                    if (second.Count == 0)
                    {
                        return "first " + moveCount.ToString();
                    }
                }
                moveCount++;
            }

            return "botva";
        }
    }


    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }

    public class Deque<T> : IEnumerable<T>
    {
        DoublyNode<T> head;
        DoublyNode<T> tail;
        int count;


        public void AddLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        public T DequeueFirst()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;
            return output;
        }
        public T DequeueLast()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = tail.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            count--;
            return output;
        }
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;
            }
        }
        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;
            }
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace ErrorProofDeck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deque<int> dequeue = new Deque<int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');

                string command = input[0];

                switch (command)
                {
                    case "push_front":
                        dequeue.AddFirst(int.Parse(input[1]));
                        Console.WriteLine("ok");
                        break;
                    case "push_back":
                        dequeue.AddLast(int.Parse(input[1]));
                        Console.WriteLine("ok");
                        break;
                    case "pop_front":
                        if (dequeue.Count > 0)
                            Console.WriteLine(dequeue.DequeueFirst());
                        else
                            Console.WriteLine("error");
                        break;
                    case "pop_back":
                        if (dequeue.Count > 0)
                            Console.WriteLine(dequeue.DequeueLast());
                        else
                            Console.WriteLine("error");
                        break;
                    case "front":
                        if (dequeue.Count > 0)
                            Console.WriteLine(dequeue.First);
                        else
                            Console.WriteLine("error");
                        break;
                    case "back":
                        if (dequeue.Count > 0)
                            Console.WriteLine(dequeue.Last);
                        else
                            Console.WriteLine("error");
                        break;
                    case "size":
                        Console.WriteLine(dequeue.Count);
                        break;
                    case "clear":
                        dequeue.Clear();
                        Console.WriteLine("ok");
                        break;
                    case "exit":
                        Console.WriteLine("bye");
                        return;
                }
            }
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

    public class Deque<T> : IEnumerable<T>  // двусвязный список
    {
        DoublyNode<T> head; // головной/первый элемент
        DoublyNode<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
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

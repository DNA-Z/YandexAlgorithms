using System;
using System.Collections.Generic;

namespace ErrorProofQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');

                string command = input[0];

                switch (command)
                {
                    case "push":
                        queue.Enqueue(int.Parse(input[1]));
                        Console.WriteLine("ok");
                        break;
                    case "pop":
                        if (queue.Count > 0)
                            Console.WriteLine(queue.Dequeue());
                        else
                            Console.WriteLine("error");
                        break;
                    case "front":
                        if (queue.Count > 0)
                            Console.WriteLine(queue.Peek());
                        else
                            Console.WriteLine("error");
                        break;
                    case "size":
                        Console.WriteLine(queue.Count);
                        break;
                    case "clear":
                        queue.Clear();
                        Console.WriteLine("ok");
                        break;
                    case "exit":
                        Console.WriteLine("bye");
                        return;
                }
            }
        }
    }
}

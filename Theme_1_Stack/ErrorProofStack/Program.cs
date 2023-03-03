
using System;
using System.Collections.Generic;

namespace ErrorProfStack.Program
{
    public class Program
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');

                string command = input[0];

                switch (command)
                {
                    case "push":
                        stack.Push(int.Parse(input[1]));
                        Console.WriteLine("ok");
                        break;
                    case "pop":
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Pop());
                        else
                            Console.WriteLine("error");
                        break;
                    case "back":
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Peek());
                        else
                            Console.WriteLine("error");
                        break;
                    case "size":
                        Console.WriteLine(stack.Count);
                        break;
                    case "clear":
                        stack.Clear();
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

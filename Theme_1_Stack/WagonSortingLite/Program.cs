using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters;
using System.Threading;

namespace WagonSortingLite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = Int32.Parse(Console.ReadLine());

            int[] input = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();

            Console.WriteLine(GetCorrectSort(input));
        }

        static string GetCorrectSort(int[] input)
        {
            Stack<int> stack = new Stack<int>();
            int[] result = new int[input.Length];

            int count = 1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == count)
                {
                    result[count - 1] = count;
                    count++;
                }
                else
                {
                    stack.Push(input[i]);
                }

            label:
                if (stack.Count > 0 && stack.Peek() == count)
                {
                    result[count - 1] = stack.Pop();
                    count++;
                    goto label;
                }
            }
            if (stack.Count > 0)
            {
                while (stack.Count > 0)
                {
                    result[count - 1] = stack.Pop();
                    count++;
                }
            }

            if (IsSorted(result))
                return "YES";
            else
                return "NO";
        }

        static bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                    return false;
            }
            return true;
        }
    }
}

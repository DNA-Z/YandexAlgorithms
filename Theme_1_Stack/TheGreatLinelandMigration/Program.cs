using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TheGreatLinelandMigration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int count = Int32.Parse(Console.ReadLine());

            //int[] input = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();

            int[] input = { 1, 2, 3, 2, 1, 4, 2, 5, 3, 1 };

            //  1 2 3 2  1 4 2 5 3  1
            // -1 4 3 4 -1 6 9 8 9 -1

            Console.WriteLine(GetMigration(input));
        }

        static int GetMigration(int[] input)
        {
            Stack<int> stack = new Stack<int>();

            BinaryExpression b = new BinaryExpression();

            b.

            int result = 0;

            return result;
        }
    }
}

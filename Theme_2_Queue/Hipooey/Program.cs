using System;
using System.Collections.Generic;
using System.Linq;

namespace Hipooey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Heap heap = new Heap();

            int commandCount = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < commandCount; i++)
            {
                int[] input = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

                switch(input[0])
                {
                    case 0:
                        heap.Input(input[1]);
                        break;
                    case 1:
                        if(heap.Count > 0)
                        {
                            Console.WriteLine(heap.Extract());
                        }                        
                        break;
                }
            }
        }
    }


    public class Heap
    {
        static List<int> list = new List<int>();

        public int Count
        {
            get
            {
                return list.Count();
            }
        }

        public void Input(int value)
        {
            list.Add(value);
            int i = Count - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && list[parent] < list[i])
            {
                int temp = list[i];
                list[i] = list[parent];
                list[parent] = temp;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public int Extract()
        {
            int result = list[0];
            list[0] = list[Count - 1];
            list.RemoveAt(Count - 1);
            RecoveringHeap(result);
            return result;
        }

        public void RecoveringHeap(int i)
        {
            int leftChild;
            int rightChild;
            int largestChild;

            for (; ; )
            {
                leftChild = 2 * i + 1;
                rightChild = 2 * i + 2;
                largestChild = i;

                if (leftChild < Count && list[leftChild] > list[largestChild])
                {
                    largestChild = leftChild;
                }

                if (rightChild < Count && list[rightChild] > list[largestChild])
                {
                    largestChild = rightChild;
                }

                if (largestChild == i)
                {
                    break;
                }

                int temp = list[i];
                list[i] = list[largestChild];
                list[largestChild] = temp;
                i = largestChild;
            }
        }
    }
}

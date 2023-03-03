using System;
using System.Collections;
using System.Collections.Generic;

namespace PostfixNotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetCalculate(input));
        }

        static int GetCalculate(string input)
        {
            Stack<int> stack = new Stack<int>();
            string[] inputs = input.Split(' ');
            int firstOperand;
            int secondOperand;
            int result = 0;

            for (int i = 0; i < inputs.Length; i++)
            {
                if (int.TryParse(inputs[i], out var number))
                {
                    stack.Push(number);
                }
                else
                {
                    secondOperand = stack.Pop();
                    firstOperand = stack.Pop();

                    switch (inputs[i])
                    {
                        case "+":
                            result = firstOperand + secondOperand;
                            break;
                        case "-":
                            result = firstOperand - secondOperand;
                            break;
                        case "*":
                            result = firstOperand * secondOperand;
                            break;
                        case "/":
                            result = firstOperand / secondOperand;
                            break;
                    }

                    stack.Push(result);
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectBracketSequence
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.Write(GetCorrectBracket(input));
        }

        static string GetCorrectBracket(string input)
        {
            Stack<string> sequences = new Stack<string>();

            if (string.IsNullOrEmpty(input))
            {
                if (sequences.Count == 0)
                    return "yes";
            }
            else
            {
                for(int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '(' || input[i] == '[' || input[i] == '{')
                    {
                        sequences.Push(input[i].ToString());
                        continue;
                    }
                    else
                    {
                        if (sequences.Count == 0)
                            return "no";

                        else
                        {
                            if(input[i] == ')')
                            {
                                if(sequences.Peek() == "(")
                                {
                                    sequences.Pop();
                                    continue;
                                }
                                else
                                    return "no";
                            }
                            if (input[i] == ']')
                            {
                                if (sequences.Peek() == "[")
                                {
                                    sequences.Pop();
                                    continue;
                                }
                                else
                                    return "no";
                            }
                            if (input[i] == '}')
                            {
                                if (sequences.Peek() == "{")
                                {
                                    sequences.Pop();
                                    continue;
                                }
                                else
                                    return "no";
                            }
                        }
                    }
                }
                if(sequences.Count == 0)
                    return "yes";
            }

            return "no";
        }
    }
}

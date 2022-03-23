using System;
using System.Linq;
using System.Collections.Generic;

namespace Infix_to_PostFix
{
    class Program
    {
        static void Main(string[] args)
        {
            AddToList();
            ToPostFix(Stacks.Infix);
        }
        static void AddToList()
        {
            string Out = "";
            do
            {
                Console.WriteLine("\nEnter An Operator");
                Out = Console.ReadLine();
                if (Out == "BYE")
                {
                    return;
                }
                Stacks.Infix.Add(Out);
                Console.Clear();
                foreach (string x in Stacks.Infix)
                {
                    Console.Write(x + " ");
                }
            } while (true);
        }
        static void ToPostFix(List<string> Infix)
        {
            foreach (string x in Infix)
            {
                if (x == "+" || x == "-")
                {
                    if (Stacks.Operators[Stacks.Operators.Count - 1] == "+" || Stacks.Operators[Stacks.Operators.Count - 1] == "-")
                    {
                        Stacks.Output.Add(Stacks.Operators[Stacks.Operators.Count - 1]);
                        Stacks.Operators.RemoveAt(Stacks.Operators.Count - 1);
                    }
                }
                else if (x == "*" || x == "/")
                {

                }
                else
                {
                    Stacks.Output.Add(x);
                }
            }
            foreach (string x in Stacks.Operators)
            {
                Console.Write(x + " ");
                Console.Write("\n");
            }
            foreach (string x in Stacks.Output)
            {
                Console.Write(x + " ");
                Console.Write("\n");
            }
        }
        static void SolvePostFix()
        {

        }
    }
    class Stacks
    {
        public static List<string> Infix = new List<string>();
        public static List<string> Operators = new List<string>();
        public static List<string> Output = new List<string>();
    }
}

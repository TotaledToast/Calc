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
            SolvePostFix(Stacks.Output);
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
            List<List<string>> PresidenceList = new List<List<string>> {
                new List<string>(){"+","-","*","/"},
                new List<string>(){"1","1","2","2"}
            };
            foreach (string x in Infix)
            {
                if(PresidenceList[0].Contains(x))
                {
                    if (Stacks.Operators.Count == 0)
                    {
                        Stacks.Operators.Add(x);
                    }
                    else
                    {
                        bool StackEnd = false;
                        do
                        {
                            if (Convert.ToInt32(PresidenceList[1][PresidenceList[0].IndexOf(Stacks.Operators.Last())]) < Convert.ToInt32(PresidenceList[1][PresidenceList[0].IndexOf(x)]))
                            {
                                StackEnd = true;
                            }
                            else
                            {
                                Stacks.Output.Add(Stacks.Operators.Last());
                                Stacks.Operators.Remove(Stacks.Operators.Last());
                            }
                        } while (StackEnd == false && Stacks.Operators.Count > 0);
                        Stacks.Operators.Add(x);
                    }
                }
                else
                {
                    Stacks.Output.Add(x);
                }
            }
            foreach (string x in Stacks.Operators)
            {
                Stacks.Output.Add(x);
            }
        }
        static void SolvePostFix(List<string> Input)
        {
            List<string> OperatorsList = new List<string> { 
                "/", "*", "-", "+"
            };
            for (int i = 0; i < Input.Count; i++)
            {
                if (OperatorsList.Contains(Input[i]) == true)
                {
                    switch (Input[i])
                    {
                        case "/":
                            Input[i - 2] = (Convert.ToDouble(Input[i - 2]) / Convert.ToDouble(Input[i - 1])).ToString();
                            break;
                        case "*":
                            Input[i - 2] = (Convert.ToDouble(Input[i - 2]) * Convert.ToDouble(Input[i - 1])).ToString();
                            break;
                        case "-":
                            Input[i - 2] = (Convert.ToDouble(Input[i - 2]) - Convert.ToDouble(Input[i - 1])).ToString();
                            break;
                        case "+":
                            Input[i - 2] = (Convert.ToDouble(Input[i - 2]) + Convert.ToDouble(Input[i - 1])).ToString();
                            break;
                    }
                    Input.RemoveAt(i);
                    Input.RemoveAt(i - 1);
                    i = i - 2;
                }
            }
            Console.WriteLine("\n" + Input[0]);
        }
    }
    class Stacks
    {
        public static List<string> Infix = new List<string>();
        public static List<string> Operators = new List<string>();
        public static List<string> Output = new List<string>();
    }
}

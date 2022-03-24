using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            AddToCalculationBox(((Button)sender).Content.ToString());
            Stacks.CurrentNumber = Stacks.CurrentNumber + ((Button)sender).Content;
        }
        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            CollapseCurrentNumber();
            Stacks.Operations.Add(((Button)sender).Content.ToString());
            AddToCalculationBox(((Button)sender).Content.ToString());
        }


        private void EqualsButtonClick(object sender, RoutedEventArgs e)
        {
            string Output = "";
            CollapseCurrentNumber();
            foreach (string x in Stacks.Operations)
            {
                Output = Output + " " + x;
            }
            Output = Output + " = " + SolveInfix(Stacks.Operations).ToString();
            OutputBox.Text = Output;
            ClearButton_Click(sender, e);
            ListClear();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ListClear();
            Stacks.CurrentNumber = "";
            CalculationBox.Text = "";
        }

        private void ClearButtonSingle_Click(object sender, RoutedEventArgs e)
        {
            string RemoveSingleFromCurrentNumber()
            {
                string TempNum = "";
                for (int i = 0; i < Stacks.CurrentNumber.Length - 1; i++)
                {
                    TempNum = TempNum + Stacks.CurrentNumber[i];
                }
                return TempNum;
            }
            if (Stacks.Operations.Count == 0)
            {
                if(Stacks.CurrentNumber != "")
                {
                    Stacks.CurrentNumber = RemoveSingleFromCurrentNumber();
                }
            }
            else if(Stacks.CurrentNumber == "")
            {
                Stacks.Operations.RemoveAt(Stacks.Operations.Count - 1);
            }
            else
            {
                Stacks.CurrentNumber = RemoveSingleFromCurrentNumber();
            }
            CalculationBox.Text = "";
            foreach (string x in Stacks.Operations)
            {
                CalculationBox.Text = CalculationBox.Text + x;
            }
            if (Stacks.CurrentNumber != "")
            {
                CalculationBox.Text = CalculationBox.Text + Stacks.CurrentNumber;
            }

        }
        private void AddToCalculationBox(string Input)
        {
            CalculationBox.Text = CalculationBox.Text + Input;
        }
        private void CollapseCurrentNumber()
        {
            if (Stacks.CurrentNumber != "")
            {
                Stacks.Operations.Add(Stacks.CurrentNumber);
                Stacks.CurrentNumber = "";
            }
        }
        private double SolveInfix(List<string> Infix)
        {
            Stacks.ToPostFix(Infix);
            return Stacks.SolvePostFix(Stacks.PostFix);
        }
        private void ListClear()
        {
            Stacks.Operations.Clear();
            Stacks.Operators.Clear();
            Stacks.PostFix.Clear();
        }
    }
    public class Stacks
    {
        public static List<string> Operations = new List<string>();
        public static string CurrentNumber = "";
        public static List<string> Operators = new List<string>();
        public static List<string> PostFix = new List<string>();

        public static void ToPostFix(List<string> Infix)
        {
            List<List<string>> PresidenceList = new List<List<string>> {
                new List<string>(){"+","-","*","/"},
                new List<string>(){"1","1","2","2"}
            };
            foreach (string x in Infix)
            {
                if (PresidenceList[0].Contains(x))
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
                                Stacks.PostFix.Add(Stacks.Operators.Last());
                                Stacks.Operators.Remove(Stacks.Operators.Last());
                            }
                        } while (StackEnd == false && Stacks.Operators.Count > 0);
                        Stacks.Operators.Add(x);
                    }
                }
                else
                {
                    Stacks.PostFix.Add(x);
                }
            }
            foreach (string x in Stacks.Operators)
            {
                Stacks.PostFix.Add(x);
            }
        }
        public static double SolvePostFix(List<string> Input)
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
            return Convert.ToDouble(Input[0]);
        }
    }
}

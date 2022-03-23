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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            AddToCalculationBox(Button1.Content.ToString());
            Stacks.CurrentNumber = Stacks.CurrentNumber + Button1.Content;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            AddToCalculationBox(Button2.Content.ToString());
            Stacks.CurrentNumber = Stacks.CurrentNumber + Button2.Content;
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            AddToCalculationBox(Button3.Content.ToString());
            Stacks.CurrentNumber = Stacks.CurrentNumber + Button3.Content;
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            AddToCalculationBox(Button4.Content.ToString());
            Stacks.CurrentNumber = Stacks.CurrentNumber + Button4.Content;
        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            AddToCalculationBox(Button5.Content.ToString());
            Stacks.CurrentNumber = Stacks.CurrentNumber + Button5.Content;
        }
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            AddToCalculationBox(Button6.Content.ToString());
            Stacks.CurrentNumber = Stacks.CurrentNumber + Button6.Content;
        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            AddToCalculationBox(Button7.Content.ToString());
            Stacks.CurrentNumber = Stacks.CurrentNumber + Button7.Content;
        }
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            AddToCalculationBox(Button8.Content.ToString());
            Stacks.CurrentNumber = Stacks.CurrentNumber + Button8.Content;
        }
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            AddToCalculationBox(Button9.Content.ToString());
            Stacks.CurrentNumber = Stacks.CurrentNumber + Button9.Content;
        }
        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            AddToCalculationBox(Button0.Content.ToString());
            Stacks.CurrentNumber = Stacks.CurrentNumber + Button0.Content;
        }

        private void EqualsButtonClick(object sender, RoutedEventArgs e)
        {
            string Output = "";
            CollapseCurrentNumber();
            foreach (string x in Stacks.Operations)
            {
                Output = Output + " " + x;
            }
            Output = Output +" = "+ SolveInfix(Stacks.Operations).ToString();
            OutputBox.Text = Output;
            ClearButton_Click(sender, e);
            ListClear();
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            CollapseCurrentNumber();
            Stacks.Operations.Add(DivideButton.Content.ToString());
            AddToCalculationBox(DivideButton.Content.ToString());
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            CollapseCurrentNumber();
            Stacks.Operations.Add(MultiplyButton.Content.ToString());
            AddToCalculationBox(MultiplyButton.Content.ToString());
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            CollapseCurrentNumber();
            Stacks.Operations.Add(MinusButton.Content.ToString());
            AddToCalculationBox(MinusButton.Content.ToString());
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            CollapseCurrentNumber();
            Stacks.Operations.Add(PlusButton.Content.ToString());
            AddToCalculationBox(PlusButton.Content.ToString());
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ListClear();
            Stacks.CurrentNumber = "";
            CalculationBox.Text = "";
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
        private int SolveInfix(List<string> Infix)
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
        public static int SolvePostFix(List<string> Input)
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
            return Convert.ToInt32(Input[0]);
        }
    }
}

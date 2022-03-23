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
            CalculationStack.Operations.Add(Button1.Content.ToString());
            AddToCalculationBox(Button1.Content.ToString());
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Add(Button2.Content.ToString());
            AddToCalculationBox(Button2.Content.ToString());
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Add(Button3.Content.ToString());
            AddToCalculationBox(Button3.Content.ToString());
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Add(Button4.Content.ToString());
            AddToCalculationBox(Button4.Content.ToString());
        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Add(Button5.Content.ToString());
            AddToCalculationBox(Button5.Content.ToString());
        }
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Add(Button6.Content.ToString());
            AddToCalculationBox(Button6.Content.ToString());
        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Add(Button7.Content.ToString());
            AddToCalculationBox(Button7.Content.ToString());
        }
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Add(Button8.Content.ToString());
            AddToCalculationBox(Button8.Content.ToString());
        }
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Add(Button9.Content.ToString());
            AddToCalculationBox(Button9.Content.ToString());
        }
        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Add(Button0.Content.ToString());
            AddToCalculationBox(Button0.Content.ToString());
        }

        private void EqualsButtonClick(object sender, RoutedEventArgs e)
        {
            string Output = "";
            foreach (string x in CalculationStack.Operations)
            {
                Output = Output + x;
            }
            OutputBox.Text = Output;
            ClearButton_Click(sender, e);
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Add(DivideButton.Content.ToString());
            AddToCalculationBox(DivideButton.Content.ToString());
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Add(MultiplyButton.Content.ToString());
            AddToCalculationBox(MultiplyButton.Content.ToString());
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Add(MinusButton.Content.ToString());
            AddToCalculationBox(MinusButton.Content.ToString());
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Add(PlusButton.Content.ToString());
            AddToCalculationBox(PlusButton.Content.ToString());
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            CalculationStack.Operations.Clear();
            CalculationBox.Text = "";
        }
        private void AddToCalculationBox(string Input)
        {
            CalculationBox.Text = CalculationBox.Text + Input;
        }
    }
    public class CalculationStack
    {
        public static List<string> Operations = new List<string>();
    }
}

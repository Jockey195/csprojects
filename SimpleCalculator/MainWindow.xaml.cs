using System.Windows;
using System.Windows.Controls;

namespace SimpleCalculator
{

    public partial class MainWindow : Window
    {
        private decimal _value1;
        private decimal _value2;
        private Operation _operation;
        private string _input = "";
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            txtOutput.Text = _input;
        }

        private void DigitButtons_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button clickedButton = (Button)e.Source;
                string item = clickedButton.Content.ToString();
                _input += item;
                txtOutput.Text = _input;
                txtOutput.CaretIndex = txtOutput.Text.Length;
            }
            catch (Exception)
            {
                MessageBox.Show("проблема с вводом");
            }
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _operation = Operation.Division;
                _value1 = Convert.ToDecimal(_input);
                _input = "";
            }
            catch (Exception)
            {
                MessageBox.Show("проблема с вводом");
                return;
            }
            _operation = Operation.Division;
            _value1 = Convert.ToDecimal(_input);
            _input = "";
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _operation = Operation.Multiplication;
                _value1 = Convert.ToDecimal(_input);
                _input = "";
            }
            catch (Exception)
            {
                MessageBox.Show("проблема с вводом");
            }
            //_operation = Operation.Multiplication;
            //_value1 = Convert.ToDecimal(_input);
            //_input = "";
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _operation = Operation.Subtraction;
                _value1 = Convert.ToDecimal(_input);
                _input = "";
            }
            catch (Exception)
            {
                MessageBox.Show("проблема с вводом");
            }
            //_operation = Operation.Subtraction;
            //_value1 = Convert.ToDecimal(_input);
            //_input = "";

        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _operation = Operation.Addition;
                _value1 = Convert.ToDecimal(_input);
                _input = "";
            }
            catch (Exception)
            {
                MessageBox.Show("проблема с вводом");
            }
            //_operation = Operation.Addition;
            //_value1 = Convert.ToDecimal(_input);
            //_input = "";

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            decimal result = 0;
            switch (_operation)
            {
                case Operation.Addition:
                    _value2 = Convert.ToDecimal(_input);
                    result = _value1 + _value2;
                    break;
                case Operation.Subtraction:
                    _value2 = Convert.ToDecimal(_input);
                    result = _value1 - _value2;
                    break;
                case Operation.Division:
                    _value2 = Convert.ToDecimal(_input);
                    result = _value1 / _value2;
                    break;
                case Operation.Multiplication:
                    _value2 = Convert.ToDecimal(_input);
                    result = _value1 * _value2;
                    break;
                default:
                    break;
            }
            _input = result.ToString();
            txtOutput.Text = result.ToString();
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Clear();
        }
    }
}
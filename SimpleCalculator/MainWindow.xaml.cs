using System.Globalization;
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

            // Создаем новые региональные настройки где разделителем десятичной части служит ","
            var peremennayaCultureInfo = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            peremennayaCultureInfo.NumberFormat.NumberDecimalSeparator = ",";

            // Назначаем созданные настройки, выполняемому потоку (текущей программе)
            Thread.CurrentThread.CurrentCulture = peremennayaCultureInfo;
        }

        private void DigitButtons_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button clickedButton = (Button)e.Source;
                string? item = clickedButton.Content.ToString();
                _input += item;
                txtOutput.Text = _input;
                txtOutput.CaretIndex = txtOutput.Text.Length;
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод");
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
                MessageBox.Show("Неверный ввод");
                return;
            }
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
                MessageBox.Show("Неверный ввод");
            }
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
                MessageBox.Show("Неверный ввод");
            }
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
                MessageBox.Show("Неверный ввод");
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            decimal result = 0;
            //try
            //{
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
                        if (_value2 == 0)
                        {
                            MessageBox.Show("На нуль делить нельзя");
                            return;
                        }
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
            //}
            //catch (Exception)
            //{
                //MessageBox.Show("Введите значения для операции");
            //}
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Clear();
            _input = "";
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();

        }
    }
}
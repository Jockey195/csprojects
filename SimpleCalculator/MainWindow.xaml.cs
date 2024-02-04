using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimpleCalculator
{

    public partial class MainWindow : Window
    {
        private decimal? _value1;
        private decimal? _value2;
        private Operation? _operation;
        private string _input;

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
            Clear();

        }
        private void AddToInput(string keyValue)
        {
            _input += keyValue;
            txtOutput.Text = _input;
            txtOutput.CaretIndex = txtOutput.Text.Length;

            if (_operation != null && _value1 != null)
            {
                btnCalculate.IsEnabled = true;
                _value2 = Convert.ToDecimal(_input);
            }
            else
            {
                _value1 = Convert.ToDecimal(_input);
            }
        }
        private void DigitButtons_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)e.Source;
            string item = clickedButton.Content.ToString()!;
            AddToInput(item);
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            SetOperation(Operation.Division);
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            SetOperation(Operation.Multiplication);

        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            SetOperation(Operation.Subtraction);
        }

        private void SetOperation(Operation operation)
        {
            _input = "";
            _operation = operation;
        }
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            SetOperation(Operation.Addition);
        }

        private void Calculate ()
        {
            decimal? result = 0;
            switch (_operation)
            {
                case Operation.Addition:

                    result = _value1 + _value2;
                    break;
                case Operation.Subtraction:

                    result = _value1 - _value2;
                    break;
                case Operation.Division:

                    if (_value2 == 0)
                    {
                        MessageBox.Show("На нуль делить нельзя");
                        return;
                    }
                    result = _value1 / _value2;
                    break;
                case Operation.Multiplication:
                    result = _value1 * _value2;
                    break;
                default:
                    break;
            }
            _input = result.ToString()!;
            txtOutput.Text = result.ToString();
        }
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }
        private void Clear()
        {
            txtOutput.Clear();
            _input = "";
            _value1 = null;
            _value2 = null;
            _operation = null;
            btnCalculate.IsEnabled = false;
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
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

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            // 1. Взять название нажатой кнопки (например NumPad5)
            // 2. Узнать является ли нажатая кнопка от 0 до 9 или же кнопка "/", "*", "-", "+", ","
            // 3. Если нажата кнопка числа или запятой - добавить в инпут
            // 4. Иначе Если нажата кнопка операции, выполняем метод соответствующей операции

            // 1 шаг
            string keyValue = e.Key.ToString();
            
            // Обработка чисел
            bool isDDigit = keyValue.Length == 2 && keyValue[0] == 'D';
            bool isNumDigit = keyValue.Length == 7 && keyValue.StartsWith("NumPad");
            if (isDDigit || isNumDigit)
            {
                string keyNumber = keyValue[keyValue.Length - 1].ToString();
                AddToInput(keyNumber);
                return;
            }

            // Обработка запятой
            bool isZapyatoy = keyValue == "OemComma" || keyValue == "Decimal" || keyValue == "OemQuestions";
            if (isZapyatoy)
            {
                AddToInput(",");
                return;
            }

            // Обработка операций

            bool isPlus = keyValue == "OemPlus" || keyValue == "Add";
            bool isMinus = keyValue == "OemMinus" || keyValue == "Subtract";
            bool isDivide = keyValue == "Divide";
            bool isMultiply = keyValue == "Multiply";


            if (isPlus)
            {
                SetOperation(Operation.Addition);
            }
            else if (isMinus)
            {
                SetOperation(Operation.Subtraction);
            }
            else if (isDivide)
            {
                SetOperation(Operation.Division);
            }
            else if (isMultiply)
            {
                SetOperation(Operation.Multiplication);
            }

            bool isEnter = keyValue == "Return";
            if (isEnter)
            {
                Calculate();
            }
        }
    }
}
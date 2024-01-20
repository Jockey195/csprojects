using System.Text;

namespace ConsoleUtils
{
    public static class InputService
    {
        public static double? GetDouble()
        {
            // Создается пустая переменная для результата
            double result;

            // Берем ввод пользователя и сохраняем как строку в input
            string? input = Console.ReadLine();

            bool parsingResult = double.TryParse(input, out result);
            if (!parsingResult)
            {
                Console.WriteLine("Неверный ввод");
            }

            return result;
        }

        public static char GetOption(string message, Dictionary<char, string> options)
        {

            Console.WriteLine(message);

            foreach (var option in options)
            {
                Console.WriteLine($"{option.Key} {option.Value}");
            }

            try
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                Console.Clear();

                // Пытаемся получить числовое значение
                char mode = input.KeyChar;
                if (!options.ContainsKey(mode) && mode != '\r')
                {
                    // Если ошибка, запускаем текущий метод, заново
                    return GetOption(message, options);
                }

                // Если код дошел сюда, возвращаем значение выбранного режима
                return mode;
            }
            catch (Exception)
            {
                // Если ошибка, запускаем текущий метод, заново
                return GetOption(message, options);
            }
        }

        public static string? GetString()
        {
            var input = Console.ReadLine();
            Console.InputEncoding = Encoding.UTF8;
            return string.IsNullOrWhiteSpace(input) ? null : input;
        }
    }
}

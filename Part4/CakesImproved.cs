﻿using ConsoleUtils;

namespace movsar_part4
{
    internal class CakesImproved
    {
        public static void Start()
        {
            const string PATH = @"CakesPrice.txt";

            // Выбор режима
            string[] modes = { "1 - Выбор торта", "2 - Внести в прайс новый торт" };
            int? mode = InputService.SelectMode(modes);

            switch (mode)
            {
                case 1:
                    Console.WriteLine("Введите название торта: ");
                    string? selectedName = Console.ReadLine();

                    string contents = File.ReadAllText(PATH);
                    string[] entries = contents.Split("\r\n");

                    bool found = false;

                    for (int i = 0; i < entries.Length - 1; i++)
                    {
                        string entry = entries[i].ToLower();

                        if (entry.Contains(selectedName.ToLower()))
                        {
                            found = true;
                            string[] data = entry.Split(" ");
                            Console.WriteLine($"Название торта: {data[0]}, Цена: {data[1]} руб.");
                        }
                    }
                    if (found == false)
                    {
                        Console.WriteLine("Нет такого торта");
                    }
                    Console.ReadKey();
                    Start();
                    break;

                case 2:
                    Console.WriteLine("Введите данные о торте");

                    Console.Write("Название торта: ");
                    string? date = Console.ReadLine();

                    Console.WriteLine("Цена торта: ");
                    string? price = Console.ReadLine();

                    try
                    {
                        File.AppendAllText(PATH, $"{date} {price}\r\n");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Нет доступа к указанному пути");
                        return;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Возникла непонятная ошибка");
                        return;
                    }

                    Console.WriteLine("Данные о торте успешно добавлены в файл");
                    Console.ReadKey();
                    Start();

                    break;
            }
        }
    }
}

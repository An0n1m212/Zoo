using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

public static class InputService
{
    private static int ReadIntSafe(string message, int min, int max)
    {
        int result;
        while (true)
        {
            Console.Write($"{message} ({min}-{max}): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out result) && result >= min && result <= max)
            {
                return result;
            }
            Console.WriteLine($"! Помилка: введіть ціле число від {min} до {max}.");
        }
    }
    private static bool ReadBoolSafe(string message)
    {
        while (true)
        {
            Console.Write($"{message} (1 - Так, 0 - Ні): ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1": return true;
                case "0": return false;
            }
            Console.WriteLine("! Помилка: введіть 1 для підтвердження або 0 для відмови.");
        }
    }

    private static double ReadDoubleSafe(string message)
    {
        double result;
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (double.TryParse(input, out result) && result >= 0)
            {
                return result;
            }
            Console.WriteLine("! Помилка: введіть коректне число (наприклад, 5 або 10,5).");
        }
    }

    public static (int type, string name, double food, bool captivity, bool social, double spec) GetAnimalData()
    {
        Console.WriteLine("\n--- Ввід даних про тварину ---");

        int type = ReadIntSafe("Оберіть вид: 1-Тигр, 2-Крокодил, 3-Кенгуру", 1, 3);

        Console.Write("Введіть ім'я: ");
        string name;
        bool tr = false;
        do
        {
            name = Console.ReadLine()?.Trim();
            tr = string.IsNullOrWhiteSpace(name);
            if (tr) { Console.Write("Ім'я не може бути порожнім. Введіть ще раз: "); }
        } while (tr);

        double food = ReadDoubleSafe("Норма корму (кг): ");

        bool captivity = ReadBoolSafe("Введіть чи розмножується");
        bool social = ReadBoolSafe("Введіть чи соціальна тварина");

        double spec = 0;
        switch (type)
        {
            case 1:
                spec = ReadDoubleSafe("Мін. площа вольєру (м²): ");
                break;
            case 2:
                spec = ReadDoubleSafe("Мін. температура вольєру (С): ");
                break;
            case 3:
                spec = ReadDoubleSafe("Мін. висота вольєру (м): ");
                break;
        }
        return (type, name, food, captivity, social, spec);
    }



    public static (string name, double area, double high, double temper, string climate) GetEnclosureData()
    {
        Console.WriteLine("\n--- Ввід даних про вольєр ---");

        Console.Write("Назва: ");
        string name = Console.ReadLine()?.Trim();

        int climateChoice = ReadIntSafe("Клімат: 1-Тропіки, 2-Савана, 3-Водойма", 1, 3);

        double area = ReadDoubleSafe("Площа вольєру (м²): ");

        double high = ReadDoubleSafe("Висота вольєру (м): ");

        double temper = ReadDoubleSafe("Температура вольєру (С): ");

        string climate = climateChoice switch
        {
            1 => "Тропіки",
            2 => "Савана",
            _ => "Водойма"
        };

        return (name, area, high, temper, climate);
    }
    public static int Choise(string b, int min, int max)
    {
        int a = ReadIntSafe(b, min, max);
        return a;
    }

    public static (double food, bool breed, bool social, double spec) GetEditAnimalData(Animal animal)
    {
        Console.WriteLine($"\n--- Редагування тварини: {animal.Name} ({animal.Species}) ---");
        double food = ReadDoubleSafe($"Нова норма корму (поточна: {animal.DailyFoodAmount}): ");
        bool breed = ReadBoolSafe("Чи може розмножуватись?");
        bool social = ReadBoolSafe("Чи є соціальною?");

        double spec = 0;
        switch (animal.Species)
        {
            case "Тигр":
                spec = ReadDoubleSafe("Нова мін. площа вольєру (м²): ");
                break;
            case "Крокодил":
                spec = ReadDoubleSafe("Нова мін. температура води (С): ");
                break;
            case "Кенгуру":
                spec = ReadDoubleSafe("Нова мін. висота стрибка (м): ");
                break;
        }
        return (food, breed, social, spec);

    }
}

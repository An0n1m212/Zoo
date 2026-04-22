// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Pair[] elements = new Pair[]
        {
            new Pair(10.5, 4.5),
            new ComplexNumber(3, 2), 
            new Pair(100, 200),
            new ComplexNumber(1, -5)
        };

        Console.WriteLine("--- Демонстрація роботи класів ---");

        foreach (var item in elements)
        {
            Console.WriteLine(item.ToString());
            Console.WriteLine($"Сума/Вигляд: {item.GetSum()}");
            Console.WriteLine($"Добуток/Результат: {item.GetProduct()}");
            Console.WriteLine($"Хеш-код: {item.GetHashCode()}");
            Console.WriteLine("----------------------------------");
        }

        Pair p1 = new Pair(5, 5);
        Pair p2 = new Pair(5, 5);
        Console.WriteLine($"Об'єкти p1 та p2 рівні: {p1.Equals(p2)}");
    }
}
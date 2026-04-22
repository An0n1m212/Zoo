﻿using System;
using System.Collections.Generic;
using System.Text;

public class Methods
{
    public static void ShowAllAnimals(List<Animal> animals)
    {
        Console.WriteLine("ПОВНИЙ СПИСОК МЕШКАНЦІВ ЗООПАРКУ");
        foreach (var animal in animals)
        {
            Console.WriteLine(animal.ToString());
        }
    }

    public static void ShowSpeciesStatistics(List<Animal> animals)
    {
        Console.WriteLine("\n[ СТАТИСТИКА ЗА ВИДАМИ ]");
        var stats = animals.GroupBy(a => a.Species)
                           .Select(g => new { Name = g.Key, Count = g.Count() });

        foreach (var item in stats)
        {
            Console.WriteLine($"- {item.Name}: {item.Count} шт.");
        }
    }

    public static void ShowFoodReport(List<Animal> animals)
    {
        Console.WriteLine("Введіть кількість діб на розрахунок корму");
        int.TryParse(Console.ReadLine(), out int days);
        double dailyTotal = animals.Sum(a => a.DailyFoodAmount);
        double periodTotal = dailyTotal * days;

        Console.WriteLine("\n[ ФІНАНСОВО-ГОСПОДАРСЬКИЙ ЗВІТ ]");
        Console.WriteLine($"Добова норма корму (всього): {dailyTotal:F2} кг");
        Console.WriteLine($"Необхідно корму на період ({days} дн.): {periodTotal:F2} кг");
        Console.WriteLine("----------------------------------------------------");
    }


}



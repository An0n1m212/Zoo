using System;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Zoo zoo = new Zoo("Київський Центральний Зоопарк");

        zoo.Load();

        int choice;
        do
        {
            Console.WriteLine($"--- {zoo.ZooName.ToUpper()} ---");
            Console.WriteLine("1 - Додати вольєр");
            Console.WriteLine("2 - Додати тварину в чергу");
            Console.WriteLine("3 - Розселити тварин");
            Console.WriteLine("4 - Редагувати тварину(Пошук за ім'ям)");
            Console.WriteLine("5 - Структура зоопарку");
            Console.WriteLine("6 - Повний список мешканців");
            Console.WriteLine("7 - Статистика видів");
            Console.WriteLine("8 - Фінансовий звіт (корм)");
            Console.WriteLine("0 - Вихід та Збереження");

            choice = InputService.Choise("\nВаш вибір", 0, 8);

            switch (choice)
            {
                case 1: zoo.AddNewEnclosure(); break;
                case 2: zoo.AddNewAnimal(); break;
                case 3: zoo.InteractiveAssignment(); break;
                case 4: zoo.EditAnimal(); break;
                case 5: zoo.ShowZooStructure(); break;
                case 6: Methods.ShowAllAnimals(zoo.GetAllZooAnimals()); break;
                case 7: Methods.ShowSpeciesStatistics(zoo.GetAllZooAnimals()); break;
                case 8: Methods.ShowFoodReport(zoo.GetAllZooAnimals()); break;
                case 0:
                    zoo.Save();
                    Console.WriteLine("Дані збережено. До зустрічі!");
                    break;
            }

            if (choice != 0)
            {
                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
                Console.Clear();
            }


        } while (choice != 0);
        Console.ReadKey();
    }
}
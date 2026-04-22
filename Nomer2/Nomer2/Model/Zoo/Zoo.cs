using System;
using System.Collections.Generic;

public class Zoo
{
    public string ZooName { get; private set; }
    private ZooManager _manager = new ZooManager();

    public Zoo(string name)
    {
        ZooName = name;
    }

    public List<Animal> GetAllZooAnimals() => _manager.GetAllAnimals();

    public void AddNewEnclosure()
    {
        var data = InputService.GetEnclosureData();
        var newEnc = new Enclosure(data.name, data.area, data.high, data.temper, data.climate);
        _manager.Enclosures.Add(newEnc);
        Console.WriteLine("Вольєр успішно створено.");
    }

    public void AddNewAnimal()
    {
        try
        {
            var data = InputService.GetAnimalData();
            var animal = AnimalFactory.CreateAnimal(data.type, data.name, data.food, data.spec, data.captivity, data.social);
            _manager.WaitingList.Add(animal);
            Console.WriteLine($"{animal.Name} доданий до списку очікування.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка створення тварини: {ex.Message}");
        }
    }

    public void InteractiveAssignment()
    {
        if (_manager.WaitingList.Count == 0)
        {
            Console.WriteLine("Список очікування порожній.");
            return;
        }

        for (int i = 0; i < _manager.WaitingList.Count; i++)
            Console.WriteLine($"{i}. {_manager.WaitingList[i]}");

        int animIdx = InputService.Choise("Оберіть номер тварини", 0, _manager.WaitingList.Count - 1);

        if (_manager.Enclosures.Count == 0)
        {
            Console.WriteLine("Немає доступних вольєрів.");
            return;
        }

        for (int i = 0; i < _manager.Enclosures.Count; i++)
            Console.WriteLine($"{i}. {_manager.Enclosures[i]}");

        int encIdx = InputService.Choise("Оберіть номер вольєра", 0, _manager.Enclosures.Count - 1);

        if (_manager.AssignToEnclosure(animIdx, encIdx))
            Console.WriteLine("Тварину успішно розселено!");
        else
            Console.WriteLine("Помилка: Кліматичні умови вольєра не підходять цій тварині.");
    }

    public void ShowZooStructure()
    {
        Console.WriteLine($"\n--- СТРУКТУРА ЗООПАРКУ: {ZooName} ---");
        foreach (var enc in _manager.Enclosures)
        {
            Console.WriteLine(enc.ToString());
            foreach (var anim in enc.Inhabitants)
                Console.WriteLine($"  └─ {anim.Species}: {anim.Name}");
        }
    }

    public void Save() => DataService.Save(_manager.Enclosures, _manager.WaitingList);

    public void Load()
    {
        var (encs, waits) = DataService.Load();
        _manager.Enclosures = encs;
        _manager.WaitingList = waits;
    }

    public void EditAnimal()
    {
        Console.Write("Введіть ім'я тварини для редагування: ");
        string name = Console.ReadLine()?.Trim();

        Animal animal = _manager.FindAnimalByName(name);

        if (animal == null)
        {
            Console.WriteLine("Тварину не знайдено.");
            return;
        }

        var newData = InputService.GetEditAnimalData(animal);

        string resultMessage = _manager.UpdateAnimalParameters(
            animal,
            newData.food,
            newData.breed,
            newData.social,
            newData.spec
        );

        Console.WriteLine($"[SYSTEM] {resultMessage}");
    }
}
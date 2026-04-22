using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class DataService
{
    private const string AnimalsFile = "animals.txt";
    private const string EnclosuresFile = "enclosures.txt";

    public static void Save(List<Enclosure> enclosures, List<Animal> waitingList)
    {
        using (StreamWriter sw = new StreamWriter(EnclosuresFile))
        {
            foreach (var enc in enclosures)
                sw.WriteLine($"{enc.Name};{enc.Area};{enc.High};{enc.Temper};{enc.Climate}");
        }

        using (StreamWriter sw = new StreamWriter(AnimalsFile))
        {
            foreach (var enc in enclosures)
            {
                foreach (var a in enc.Inhabitants)
                {
                    sw.WriteLine($"{a.GetType().Name};{a.Name};{a.DailyFoodAmount};{a.CanBreedInCaptivity};{a.IsSocial};{GetParam(a)};{enc.Name}");
                }
            }
            foreach (var a in waitingList)
            {
                sw.WriteLine($"{a.GetType().Name};{a.Name};{a.DailyFoodAmount};{a.CanBreedInCaptivity};{a.IsSocial};{GetParam(a)};Waiting");
            }
        }
    }

    public static (List<Enclosure>, List<Animal>) Load()
    {
        var enclosures = new List<Enclosure>();
        var waitingList = new List<Animal>();

        if (!File.Exists(EnclosuresFile)) return (enclosures, waitingList);

        foreach (var line in File.ReadAllLines(EnclosuresFile))
        {
            var p = line.Split(';');
            if (p.Length < 5) continue;
            enclosures.Add(new Enclosure(p[0], double.Parse(p[1]), double.Parse(p[2]), double.Parse(p[3]), p[4]));
        }

        if (!File.Exists(AnimalsFile)) return (enclosures, waitingList);

        foreach (var line in File.ReadAllLines(AnimalsFile))
        {
            var p = line.Split(';');
            if (p.Length < 7) continue;

            string typeStr = p[0];
            string name = p[1];
            double food = double.Parse(p[2]);
            bool social = bool.Parse(p[3]);
            bool breed = bool.Parse(p[4]);
            double spec = double.Parse(p[5]);
            string location = p[6]; 

            int typeInt = typeStr switch { "Tiger" => 1, "Crocodile" => 2, "Kangaroo" => 3, _ => 1 };

            Animal a = AnimalFactory.CreateAnimal(typeInt, name, food, spec, social, breed);

            if (location == "Waiting")
                waitingList.Add(a);
            else
                enclosures.FirstOrDefault(e => e.Name == location)?.Inhabitants.Add(a);
        }
        return (enclosures, waitingList);
    }

    private static double GetParam(Animal a) => a switch
    {
        Tiger t => t.MinEnclosureArea,
        Crocodile c => c.WaterTemperature,
        Kangaroo k => k.MaxJumpHeight,
        _ => 0
    };
}
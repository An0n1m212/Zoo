using System;
using System.Collections.Generic;
using System.Text;

public class ZooManager
{
    public List<Enclosure> Enclosures { get; set; } = new List<Enclosure>();
    public List<Animal> WaitingList { get; set; } = new List<Animal>();

    public List<Animal> GetAllAnimals()
    {
        List<Animal> all = new List<Animal>();
        foreach (var e in Enclosures) all.AddRange(e.Inhabitants);
        all.AddRange(WaitingList);
        return all;
    }

    public bool AssignToEnclosure(int animIdx, int encIdx)
    {
        var animal = WaitingList[animIdx];
        var enclosure = Enclosures[encIdx];

        if (animal.PreferredClimate == enclosure.Climate)
        {
            enclosure.Inhabitants.Add(animal);
            WaitingList.RemoveAt(animIdx);
            return true;
        }
        return false;
    }

    public Animal FindAnimalByName(string name)
    {
        var animal = Enclosures.SelectMany(e => e.Inhabitants)
                              .FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        return animal ?? WaitingList.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public string UpdateAnimalParameters(Animal animal, double newFood, bool newBreed, bool newSocial, double newSpec)
    {
        animal.DailyFoodAmount = newFood;
        animal.CanBreedInCaptivity = newBreed;
        animal.IsSocial = newSocial;

        switch (animal)
        {
            case Tiger t: t.MinEnclosureArea = newSpec; break;
            case Crocodile c: c.WaterTemperature = newSpec; break;
            case Kangaroo k: k.MaxJumpHeight = newSpec; break;
        }

        Enclosure currentEnc = Enclosures.FirstOrDefault(e => e.Inhabitants.Contains(animal));

        if (currentEnc != null)
        {
            
            if (!IsEnclosureSuitable(animal, currentEnc))
            {
                currentEnc.Inhabitants.Remove(animal);
                WaitingList.Add(animal);
                return $"Увага! Через зміну параметрів вольєр '{currentEnc.Name}' більше не підходить. Тварину переведено в чергу.";
            }
        }

        return "Параметри оновлено.";
    }

    private bool IsEnclosureSuitable(Animal animal, Enclosure enclosure)
    {
        if (animal.PreferredClimate != enclosure.Climate) return false;

        return animal switch
        {
            Tiger t => enclosure.Area >= t.MinEnclosureArea,
            Crocodile c => Math.Abs(enclosure.Temper - c.WaterTemperature) <= 5,
            Kangaroo k => enclosure.High >= k.MaxJumpHeight,
            _ => true
        };
    }
}
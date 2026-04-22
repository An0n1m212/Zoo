using System;

public abstract class Animal
{
    public string Name { get; set; }
    public string Species { get; protected set; }
    public double DailyFoodAmount { get; set; } 
    public bool CanBreedInCaptivity { get; set; }
    public bool IsSocial { get; set; }

    public string PreferredClimate { get; set; }

    public Animal(string name, double foodAmount, bool canBreed, bool isSocial, string climate)
    {
        Name = name;
        DailyFoodAmount = foodAmount;
        CanBreedInCaptivity = canBreed;
        IsSocial = isSocial;
        PreferredClimate = climate;
    }

    public abstract string GetFoodType();

    public override string ToString()
    {
        return $"[{Species}] Ім'я: {Name}, Корм: {DailyFoodAmount}кг/день ({GetFoodType()}), (Клімат: {PreferredClimate}), " +
               $"Розмноження: {(CanBreedInCaptivity ? "Так" : "Ні")}, Соціальність: {(IsSocial ? "Так" : "Ні")}";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Species);
    }
}
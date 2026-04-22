using System;
using System.Collections.Generic;
using System.Text;

public static class AnimalFactory
{
    public static Animal CreateAnimal(int type, string name, double food, double specParam, bool captivity, bool social)
    {
        return type switch
        {
            1 => new Tiger(name, food, captivity, social, specParam),
            2 => new Crocodile(name, food, captivity, social, specParam),
            3 => new Kangaroo(name, food, captivity, social, specParam),
            _ => throw new ArgumentException("Невідомий тип тварини")
        };
    }
}

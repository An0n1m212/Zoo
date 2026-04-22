using System;
using System.Collections.Generic;
using System.Text;


public class Enclosure
{
    public string Name { get; set; }
    public double Area { get; set; }
    public double High { get; set; }
    public double Temper { get; set; }
    public string Climate { get; set; }
    public List<Animal> Inhabitants { get; set; }

    public Enclosure(string name, double area, double high, double temper, string environment)
    {
        Name = name;
        Area = area;
        High = high; 
        Temper = temper;
        Climate = environment;
        Inhabitants = new List<Animal>();
    }

    public override string ToString()
    {
        return $"Вольєр: {Name} | Площа: {Area}м² | Висота: {High}м | Температура: {Temper}м | Умови: {Climate} | Тварин: {Inhabitants.Count}";
    }
}


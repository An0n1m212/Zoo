public class Tiger : Animal
{
    public double MinEnclosureArea { get; set; } 

    public Tiger(string name, double foodAmount,bool captivity, bool social, double area)
        : base(name, foodAmount, captivity, social, "Тропіки") 
    {
        Species = "Тигр";
        MinEnclosureArea = area;
    }

    public override string GetFoodType() => "М'ясо (яловичина/кролятина)";

    public override string ToString() => base.ToString() + $", Площа вольєру: {MinEnclosureArea}м²";
}
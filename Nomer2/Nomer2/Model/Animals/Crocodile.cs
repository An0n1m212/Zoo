public class Crocodile : Animal
{
    public double WaterTemperature { get; set; } 

    public Crocodile(string name, double foodAmount, bool captivity, bool social, double temp)
        : base(name, foodAmount, captivity, social, "Водойма")
    {
        Species = "Крокодил";
        WaterTemperature = temp;
    }

    public override string GetFoodType() => "Риба та дрібні ссавці";

    public override string ToString() => base.ToString() + $", Температура води: {WaterTemperature}°C";
}
public class Kangaroo : Animal
{
    public double MaxJumpHeight { get; set; } 

    public Kangaroo(string name, double foodAmount, bool captivity, bool social, double jump)
        : base(name, foodAmount, captivity, social, "Савана")
    {
        Species = "Кенгуру";
        MaxJumpHeight = jump;
    }

    public override string GetFoodType() => "Рослинна їжа (трава, сіно, овочі)";

    public override string ToString() => base.ToString() + $", Висота стрибка: {MaxJumpHeight}м";
}
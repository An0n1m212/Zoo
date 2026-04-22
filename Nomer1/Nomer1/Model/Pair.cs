using System;

public class Pair
{
    protected double first;
    protected double second;

    public Pair(double first, double second)
    {
        this.first = first;
        this.second = second;
    }

    public double First
    {
        get => first;
        set => first = value;
    }

    public double Second
    {
        get => second;
        set => second = value;
    }

    public virtual string GetSum()
    {
        return (first + second).ToString();
    }

    public virtual string GetProduct()
    {
        return (first * second).ToString();
    }

    public override string ToString()
    {
        return $"Числа: ({first}; {second})";
    }

    public override bool Equals(object obj)
    {
        if (obj is Pair other)
        {
            return this.first == other.first && this.second == other.second;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(first, second);
    }
}
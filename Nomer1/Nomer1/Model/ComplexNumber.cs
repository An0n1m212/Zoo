using System;

public class ComplexNumber : Pair
{
    public ComplexNumber(double real, double imaginary) : base(real, imaginary) { }

    public override string GetSum()
    {
        double realSum = first; 
                                
        return $"{first} + {second}i";
    }
    public override string GetProduct()
    {
        return "Для множення комплексних чисел потрібен другий операнд";
    }

    public override string ToString()
    {
        return $"Комплексне число: {first} + {second}i";
    }

    public override bool Equals(object obj)
    {
        if (obj is ComplexNumber other)
        {
            return this.first == other.first && this.second == other.second;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
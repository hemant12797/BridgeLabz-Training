using System;

public interface IRentable
{
    double CalculateRent(int days);
}

public class Vehicle
{
    protected string model;
    protected double baseRent;

    public Vehicle(string model, double baseRent)
    {
        this.model = model;
        this.baseRent = baseRent;
    }

    public string GetModel()
    {
        return model;
    }

    public double GetBaseRent()
    {
        return baseRent;
    }
}

public class Bike : Vehicle, IRentable
{
    public Bike(string model, double baseRent) : base(model, baseRent) { }

    public double CalculateRent(int days)
    {
        return baseRent * days;
    }
}

public class Car : Vehicle, IRentable
{
    public Car(string model, double baseRent) : base(model, baseRent) { }

    public double CalculateRent(int days)
    {
        return baseRent * days * 1.2;
    }
}

public class Truck : Vehicle, IRentable
{
    public Truck(string model, double baseRent) : base(model, baseRent) { }

    public double CalculateRent(int days)
    {
        return baseRent * days * 1.5;
    }
}

public class Customer
{
    public string Name { get; set; }
    public string LicenseNumber { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Customer: {Name}, License: {LicenseNumber}");
    }
}

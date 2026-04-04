using System;
using System.Collections.Generic;

public interface IFlyable
{
    void Fly();
}

public interface ISwimmable
{
    void Swim();
}

public class Bird
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Bird(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class Eagle : Bird, IFlyable
{
    public Eagle(string name, int age) : base(name, age) { }

    public void Fly()
    {
        Console.WriteLine($"{Name} is soaring high in the sky.");
    }
}

public class Sparrow : Bird, IFlyable
{
    public Sparrow(string name, int age) : base(name, age) { }

    public void Fly()
    {
        Console.WriteLine($"{Name} is fluttering around the trees.");
    }
}

public class Duck : Bird, ISwimmable
{
    public Duck(string name, int age) : base(name, age) { }

    public void Swim()
    {
        Console.WriteLine($"{Name} is paddling in the pond.");
    }
}

public class Penguin : Bird, ISwimmable
{
    public Penguin(string name, int age) : base(name, age) { }

    public void Swim()
    {
        Console.WriteLine($"{Name} is diving deep into the ocean.");
    }
}

public class Seagull : Bird, IFlyable, ISwimmable
{
    public Seagull(string name, int age) : base(name, age) { }

    public void Fly()
    {
        Console.WriteLine($"{Name} is gliding over the waves.");
    }

    public void Swim()
    {
        Console.WriteLine($"{Name} is floating on the water.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Bird> birds = new List<Bird>
        {
            new Eagle("Baldy", 5),
            new Sparrow("Tweety", 2),
            new Duck("Quacky", 3),
            new Penguin("Waddles", 4),
            new Seagull("Squawk", 3)
        };

        foreach (var bird in birds)
        {
            if (bird is IFlyable flyable)
            {
                flyable.Fly();
            }
            if (bird is ISwimmable swimmable)
            {
                swimmable.Swim();
            }
        }
    }
}

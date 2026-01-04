
class Animal
{
    public string Name;
    public int Age;

    public virtual void MakeSound()
    {
        System.Console.WriteLine("Animal makes a sound");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        System.Console.WriteLine("Dog barks");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        System.Console.WriteLine("Cat meows");
    }
}

class Bird : Animal
{
    public override void MakeSound()
    {
        System.Console.WriteLine("Bird chirps");
    }
}

using System;
class AreaOfCircle
{
    private double radius;
    public AreaOfCircle(double radius)
    {
        this.radius = radius;
    }
    public void Area()
    {
        double A = Math.PI*this.radius*this.radius;
        Console.WriteLine($"Area Of Circle ====>   {A}");
    }

    public void Perimeter()
    {
        double P = 2*Math.PI*this.radius;
        Console.WriteLine($"Circumference Of Circle ====>   {P}");
    }
}

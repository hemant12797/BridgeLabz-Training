using System;
public class cylinderVolume{
    static void Main(string[] args){
        double radius = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        double volume = Math.PI*radius*radius*height;
        Console.WriteLine("Volume --> "+volume);
    }
}
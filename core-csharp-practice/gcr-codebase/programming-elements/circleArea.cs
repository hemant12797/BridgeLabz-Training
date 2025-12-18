using System;
public class circleArea{
    static void Main(string[] args){
        int radius = int.Parse(Console.ReadLine());
        double area = Math.PI*radius*radius;
        Console.WriteLine("Area --> "+area);
    }
}
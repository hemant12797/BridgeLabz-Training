using System;
public class numberAVG{
    static void Main(string[] args){
        double num1 = double.Parse(Console.ReadLine());
        double num2 = double.Parse(Console.ReadLine());
        double num3 = double.Parse(Console.ReadLine());
        double avg = (num1+num2+num3)/3;
        Console.WriteLine("AVG --> "+avg);
    }
}
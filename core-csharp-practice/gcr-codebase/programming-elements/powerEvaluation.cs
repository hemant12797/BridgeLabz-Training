using System;
public class powerEvaluation{
    static void Main(string[] args){
        double baseValue = double.Parse(Console.ReadLine());
        double exponent = double.Parse(Console.ReadLine());
        double result = Math.Pow(baseValue,exponent);

        Console.WriteLine("Result --> "+result);
    }
}
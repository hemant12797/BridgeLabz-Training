using System;
public class SI{
    static void Main(string[] args){
        double principle = double.Parse(Console.ReadLine());
        double rate = double.Parse(Console.ReadLine());
        double time = double.Parse(Console.ReadLine());
        double SI = (principle*rate*time)/100;
        Console.WriteLine("SI --> "+SI);
    }
}
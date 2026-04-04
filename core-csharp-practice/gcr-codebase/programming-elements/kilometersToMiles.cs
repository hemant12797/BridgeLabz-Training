using System;
public class kilometersToMiles{
    static void Main(string[] args){
        double kilometers = double.Parse(Console.ReadLine());
        double Miles = kilometers*0.621371;
        Console.WriteLine("Miles --> "+Miles);
    }
}
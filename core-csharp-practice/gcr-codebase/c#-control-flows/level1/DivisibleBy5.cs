using System;
public class DivisibleBy5{
public static void Main(){
int number=int.Parse(Console.ReadLine());
Console.WriteLine("Is the number "+number+" divisible by 5? "+(number%5==0));
}}
using System;
public class LargestOfThree{
public static void Main(){
int a=int.Parse(Console.ReadLine());
int b=int.Parse(Console.ReadLine());
int c=int.Parse(Console.ReadLine());
Console.WriteLine("Is the first number the largest? "+(a>b && a>c));
Console.WriteLine("Is the second number the largest? "+(b>a && b>c));
Console.WriteLine("Is the third number the largest? "+(c>a && c>b));
}}
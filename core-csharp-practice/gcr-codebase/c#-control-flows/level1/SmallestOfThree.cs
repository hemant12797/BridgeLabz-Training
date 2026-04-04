using System;
public class SmallestOfThree{
public static void Main(){
int a=int.Parse(Console.ReadLine());
int b=int.Parse(Console.ReadLine());
int c=int.Parse(Console.ReadLine());
Console.WriteLine("Is the first number the smallest? "+(a<b && a<c));
}}
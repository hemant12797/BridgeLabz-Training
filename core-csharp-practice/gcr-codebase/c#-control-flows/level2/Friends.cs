using System;
public class Friends{
public static void Main(){
int a1=int.Parse(Console.ReadLine());
int a2=int.Parse(Console.ReadLine());
int a3=int.Parse(Console.ReadLine());
double h1=double.Parse(Console.ReadLine());
double h2=double.Parse(Console.ReadLine());
double h3=double.Parse(Console.ReadLine());
int minAge=Math.Min(a1,Math.Min(a2,a3));
double maxHeight=Math.Max(h1,Math.Max(h2,h3));
Console.WriteLine(minAge);
Console.WriteLine(maxHeight);
}}
using System;
public class BMI{
public static void Main(){
double w=double.Parse(Console.ReadLine());
double h=double.Parse(Console.ReadLine())/100;
double bmi=w/(h*h);
Console.WriteLine(bmi);
}}
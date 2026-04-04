using System;
public class EmployeeBonus{
public static void Main(){
double salary=double.Parse(Console.ReadLine());
int years=int.Parse(Console.ReadLine());
if(years>5) Console.WriteLine(salary*0.05);
else Console.WriteLine(0);
}}
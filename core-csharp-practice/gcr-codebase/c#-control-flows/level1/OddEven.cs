using System;
public class OddEven{
public static void Main(){
int n=int.Parse(Console.ReadLine());
for(int i=1;i<=n;i++)
Console.WriteLine(i+" is "+(i%2==0?"Even":"Odd"));
}}
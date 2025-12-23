using System;
public class Power{
public static void Main(){
int n=int.Parse(Console.ReadLine());
int p=int.Parse(Console.ReadLine());
int r=1;
for(int i=1;i<=p;i++) r*=n;
Console.WriteLine(r);
}}
using System;
public class FactorialFor{
public static void Main(){
int n=int.Parse(Console.ReadLine());
long f=1;
for(int i=1;i<=n;i++) f*=i;
Console.WriteLine(f);
}}
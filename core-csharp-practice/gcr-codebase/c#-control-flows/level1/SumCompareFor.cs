using System;
public class SumCompareFor{
public static void Main(){
int n=int.Parse(Console.ReadLine());
int sum=0;
for(int i=1;i<=n;i++) sum+=i;
int formula=n*(n+1)/2;
Console.WriteLine(sum==formula);
}}
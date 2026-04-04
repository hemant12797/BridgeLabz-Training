using System;
public class SumCompareWhile{
public static void Main(){
int n=int.Parse(Console.ReadLine());
int sum=0,i=1;
while(i<=n){sum+=i;i++;}
int formula=n*(n+1)/2;
Console.WriteLine(sum==formula);
}}
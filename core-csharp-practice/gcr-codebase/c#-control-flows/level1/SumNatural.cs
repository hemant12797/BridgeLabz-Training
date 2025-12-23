using System;
public class SumNatural{
public static void Main(){
int n=int.Parse(Console.ReadLine());
if(n>=0){
int sum=n*(n+1)/2;
Console.WriteLine("The sum of "+n+" natural numbers is "+sum);
}else{
Console.WriteLine("The number "+n+" is not a natural number");
}}}
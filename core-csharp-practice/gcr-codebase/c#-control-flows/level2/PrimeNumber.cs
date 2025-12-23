using System;
public class PrimeNumber{
public static void Main(){
int n=int.Parse(Console.ReadLine());
bool isPrime=true;
if(n<=1) isPrime=false;
for(int i=2;i<n;i++){
if(n%i==0){isPrime=false;break;}
}
Console.WriteLine(isPrime);
}}
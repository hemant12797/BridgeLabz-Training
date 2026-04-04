using System;
public class MultiplesBelow100{
public static void Main(){
int n=int.Parse(Console.ReadLine());
for(int i=100;i>=1;i--){
if(i%n==0) Console.WriteLine(i);
}
}}
using System;
public class FizzBuzzFor{
public static void Main(){
int n=int.Parse(Console.ReadLine());
for(int i=0;i<=n;i++){
if(i%3==0 && i%5==0) Console.WriteLine("FizzBuzz");
else if(i%3==0) Console.WriteLine("Fizz");
else if(i%5==0) Console.WriteLine("Buzz");
else Console.WriteLine(i);
}
}}
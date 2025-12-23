using System;
public class FactorialWhile{
public static void Main(){
int n=int.Parse(Console.ReadLine());
long f=1;
while(n>0){f*=n;n--;}
Console.WriteLine(f);
}}
using System;
public class ArmstrongNumber{
public static void Main(){
int number=int.Parse(Console.ReadLine());
int originalNumber=number;
int sum=0;
while(originalNumber!=0){
int r=originalNumber%10;
sum+=r*r*r;
originalNumber/=10;
}
if(sum==number) Console.WriteLine("Armstrong Number");
else Console.WriteLine("Not an Armstrong Number");
}}
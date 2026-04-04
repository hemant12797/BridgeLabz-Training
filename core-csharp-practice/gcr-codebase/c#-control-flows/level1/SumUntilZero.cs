using System;
public class SumUntilZero{
public static void Main(){
double total=0,val;
while((val=double.Parse(Console.ReadLine()))!=0){
total+=val;
}
Console.WriteLine(total);
}}
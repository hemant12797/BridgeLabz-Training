using System;
public class SumUntilBreak{
public static void Main(){
double total=0;
while(true){
double v=double.Parse(Console.ReadLine());
if(v<=0) break;
total+=v;
}
Console.WriteLine(total);
}}
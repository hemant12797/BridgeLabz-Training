using System;
public class GreatestFactor{
public static void Main(){
int n=int.Parse(Console.ReadLine());
int gf=1;
for(int i=n-1;i>=1;i--){
if(n%i==0){gf=i;break;}
}
Console.WriteLine(gf);
}}
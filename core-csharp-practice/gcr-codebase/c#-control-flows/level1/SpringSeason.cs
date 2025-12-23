using System;
public class SpringSeason{
public static void Main(string[] args){
int month=int.Parse(args[0]);
int day=int.Parse(args[1]);
bool spring=(month==3&&day>=20)||(month==4)||(month==5)||(month==6&&day<=20);
Console.WriteLine(spring?"Its a Spring Season":"Not a Spring Season");
}}
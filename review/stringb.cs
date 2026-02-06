using System;
using System.Text;
class Stringb
{
    static void Main(String[] args)
    {
       StringBuilder sb=new StringBuilder();
       Console.WriteLine("enter the word");
       string w1=Console.ReadLine();
       sb.Append(w1);
       Console.WriteLine("enter the second word");
       string w2=Console.ReadLine();
       int index=int.Parse(Console.ReadLine());

       sb.Insert(index,w2);
       Console.WriteLine(sb); 
    }

}
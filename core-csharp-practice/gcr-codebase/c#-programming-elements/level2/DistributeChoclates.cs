using System;

public class DistributeChoclates{
    public static void Main(String[] args){
        Console.WriteLine("Enter number of choclates :");
        int numberOfChocolates = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter numberOfChildren :");
        int numberOfChildren = int.Parse(Console.ReadLine());

        int numberOfChocolatesPerChild = numberOfChocolates / numberOfChildren;

        int remainingChoclates = numberOfChocolates % numberOfChocolatesPerChild;

        Console.WriteLine("The number of chocolates each child gets is "+ numberOfChocolatesPerChild +" and the number of remaining chocolates is "+remainingChoclates);


    }
}
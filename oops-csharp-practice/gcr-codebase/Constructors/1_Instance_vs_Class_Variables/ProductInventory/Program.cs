
using System;
class Program
{
    static void Main()
    {
        Product p1 = new Product("Pen", 10);
        Product p2 = new Product("Book", 100);
        p1.DisplayProductDetails();
        Product.DisplayTotalProducts();
    }
}

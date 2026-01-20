using System;

class Program
{
    static void Main(string[] args)
    {
        Catalog catalog = new Catalog();

        // Add some products
        BookProduct book1 = new BookProduct("The Great Gatsby", 15.99, BookCategory.Fiction);
        BookProduct book2 = new BookProduct("Sapiens", 20.00, BookCategory.NonFiction);
        ClothingProduct clothing1 = new ClothingProduct("T-Shirt", 25.00, ClothingCategory.Shirt);
        ClothingProduct clothing2 = new ClothingProduct("Jeans", 50.00, ClothingCategory.Pants);

        catalog.AddProduct(book1);
        catalog.AddProduct(book2);
        catalog.AddProduct(clothing1);
        catalog.AddProduct(clothing2);

        Console.WriteLine("Products before discount:");
        catalog.DisplayAll();

        // Apply discounts
        catalog.ApplyDiscount(book1, 10); // 10% discount on book1
        catalog.ApplyDiscount(clothing1, 20); // 20% discount on clothing1

        Console.WriteLine("\nProducts after discount:");
        catalog.DisplayAll();
    }
}


class Product
{
    public string productName;
    public double price;
    public static int totalProducts = 0;

    public Product(string name, double price)
    {
        this.productName = name;
        this.price = price;
        totalProducts++;
    }

    public void DisplayProductDetails()
    {
        System.Console.WriteLine(productName + " " + price);
    }

    public static void DisplayTotalProducts()
    {
        System.Console.WriteLine("Total Products: " + totalProducts);
    }
}

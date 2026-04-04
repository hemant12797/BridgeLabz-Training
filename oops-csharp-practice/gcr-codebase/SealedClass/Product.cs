
class Product
{
    public static double Discount = 10;

    public string ProductName;
    public readonly int ProductID;
    public double Price;
    public int Quantity;

    public Product(string name, int id, double price, int qty)
    {
        this.ProductName = name;
        this.ProductID = id;
        this.Price = price;
        this.Quantity = qty;
    }

    public static void UpdateDiscount(double d)
    {
        Discount = d;
    }

    public void Process(object obj)
    {
        if (obj is Product)
            System.Console.WriteLine(ProductName + " " + ProductID + " " + Price);
    }
}

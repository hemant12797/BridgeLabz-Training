public class ClothingProduct : Product
{
    public ClothingCategory Category { get; set; }

    public ClothingProduct(string name, double price, ClothingCategory category) : base(name, price)
    {
        Category = category;
    }

    public override void Display()
    {
        Console.WriteLine($"Clothing: {Name}, Price: ${Price}, Category: {Category}");
    }
}

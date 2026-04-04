internal class Product
{
    private string _productName;
    private double _originalPrice;
    private double _discountedPrice;
    private double _discountPercent;

    public Product(string productName, double originalPrice, double discountPercent)
    {
        _productName = productName;
        _originalPrice = originalPrice;
        _discountPercent = discountPercent;
        _discountedPrice = originalPrice * (1 - (discountPercent / 100));
    }

    public double GetDiscountPercent()
    {
        return _discountPercent;
    }

    public override string ToString()
    {
        return $"\nProduct Name: {_productName}\nOriginal Price: Rs {_originalPrice}\nDiscount Percent: {_discountPercent}%\nDiscounted Price: Rs {_discountedPrice}\n";
    }
}
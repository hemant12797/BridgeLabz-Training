
using System.Collections.Generic;

class Customer
{
    public string Name;

    public Customer(string name)
    {
        Name = name;
    }
}

class Product
{
    public string ProductName;
    public Product(string name)
    {
        ProductName = name;
    }
}

class Order
{
    public Customer Customer;
    public List<Product> Products = new List<Product>();

    public Order(Customer customer)
    {
        Customer = customer;
    }
}

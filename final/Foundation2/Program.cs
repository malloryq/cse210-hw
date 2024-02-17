using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (Product product in products)
        {
            totalCost += product.GetTotalCost();
        }

        if (customer.IsInUSA())
        {
            totalCost += 5;
        }
        else
        {
            totalCost += 35;
        }

        return totalCost;
    }

    public string GeneratePackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in products)
        {
            label += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return label;
    }

    public string GenerateShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress()}";
    }
}

public class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string Name
    {
        get { return name; }
    }

    public string ProductId
    {
        get { return productId; }
    }
}

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}

public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Product product1 = new Product("Product 1", "P1", 10, 2);
        Product product2 = new Product("Product 2", "P2", 15, 3);

        Address address = new Address("123 Main St", "City", "State", "USA");

        Customer customer = new Customer("John Doe", address);

        List<Product> products = new List<Product>();
        products.Add(product1);
        products.Add(product2);
        Order order = new Order(products, customer);

        Console.WriteLine("Order Details:");
        Console.WriteLine(order.GeneratePackingLabel());
        Console.WriteLine(order.GenerateShippingLabel());
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost()}");
    }
}
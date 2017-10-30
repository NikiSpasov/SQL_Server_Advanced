using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private double money;
    private List<Product> products;

    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.Products = new List<Product>();
    }

    public string Name
    {
        get => this.name;

        private set
        {
            if (value == String.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        } 
    }

    public double Money
    {
        get => this.money;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }

    public List<Product> Products
    {
        get => this.products;
        private set => this.products = value;
    }

    public void BuyProduct(Product product)
    {
        if (product.Price <= this.Money)
        {
            this.products.Add(product);
            this.money -= product.Price;
            Console.WriteLine($"{this.name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{this.name} can't afford {product.Name}");
        }
    }

    public override string ToString()
    {
        if (this.products.Count == 0)
        {
            return $"{this.name} - Nothing bought";
        }
    
    StringBuilder sb = new StringBuilder();
        sb.Append($"{this.name} - ");
        List<string> productNames = new List<string>();
        foreach (var product in this.products)
        {
            productNames.Add(product.Name);
        }

        sb.Append(String.Join(", ", productNames));

        return sb.ToString().Trim();
    }
}

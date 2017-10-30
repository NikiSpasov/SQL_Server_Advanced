using System;

public class Product
{
    private string name;
    private double price;

    public Product(string name, double price)
    {
        this.Name = name;
        this.Price = price;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public double Price
    {
        get => this.price;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price cannot be zero or negative");
            }

            this.price = value; 
        }

    }

}


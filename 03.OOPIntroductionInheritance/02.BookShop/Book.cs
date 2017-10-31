using System;
using System.Linq;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    public string Title
    {
        get => this.title;
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public string Author
    {
        get => this.author;
        set
        {
            int emptySpaceIndex = value.IndexOf(" ");
            char a = value.Remove(0, emptySpaceIndex + 1).First();
            if (char.IsDigit(a))
            {
                throw new ArgumentException("Author not valid!");
            }
            ; 
            this.author = value;
        }
    }

    public decimal Price
    {
        get => this.price;
        protected set
        {
            if (value <= 0)
            {
                throw  new ArgumentException("Price not valid!");
            }
            this.price = value;
        } 
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}");
        sb.AppendLine($"Title: {this.Title}");
        sb.AppendLine($"Author: {this.Author}");
        sb.AppendLine($"Price: {this.Price:f2}");

        return sb.ToString().Trim();
    }
}


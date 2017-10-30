using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Permissions;
using System.Threading;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza()
    {
        this.Toppings = new List<Topping>();
    }

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
        this.Toppings = new List<Topping>();
    }

    public void AddTopping(Topping topping)
    {
        if (this.Toppings.Count < 0 || this.Toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        this.Toppings.Add(topping);
    }

    public string Name
    {
        get => this.name;
        set
        {
            if (value == string.Empty || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        } 
        
    }

    public Dough Dough
    {
        get => this.dough;
        set => this.dough = value;
    }

    public List<Topping> Toppings
    {
        get => this.toppings;
        private set => this.toppings = value;
        
    }

    public double TotalCalories
    {
        get
        {
            return this.Dough.Calories + this.Toppings.Select(x => x.Calories).Sum();
        }
    }

}
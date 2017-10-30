using System;
using System.Globalization;
using System.Linq;

public class Topping
{
    private const double CaloriesPerGram = 2.0;

    private string toppingType;
    private string calories;
    private double weightInGrams;

    public Topping(string toppingType, double weightInGrams)
    {
        this.ToppingType = toppingType;
        this.WeightInGrams = weightInGrams;
    }

    public double WeightInGrams
    {
        get => this.weightInGrams;
        private set
        {
            if (value < 1 || value > 50)
            {
                string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.toppingType);
                throw new ArgumentException($"{titleCase} weight should be in the range [1..50]."); //TO-DO!!
            }
            this.weightInGrams = value;
        }
    }

    public string ToppingType
    {
        get => this.toppingType;
        private set
        {
            if (!(value.ToLower() == "meat" || value.ToLower() == "veggies"
               || value.ToLower() == "cheese" || value.ToLower() == "sauce"))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.toppingType = value.ToLower();
        }
    }

    public double Calories
    {
        get
        {
            double toppingTypeMultiplier = 0;
            switch (this.toppingType.ToLower())
            {
                case "meat":
                    toppingTypeMultiplier = 1.2;
                    break;
                case "veggies":
                    toppingTypeMultiplier = 0.8;
                    break;
                case "cheese":
                    toppingTypeMultiplier = 1.1;
                    break;
                case "sauce":
                    toppingTypeMultiplier = 0.9;
                    break;
            }

            return CaloriesPerGram * this.weightInGrams * toppingTypeMultiplier;

        }
    }
}

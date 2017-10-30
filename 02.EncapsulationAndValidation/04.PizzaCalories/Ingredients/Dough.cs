using System;

public class Dough
{
    private const double CaloriesPerGram = 2.0;

    private string flourType;
    private string backingTechnique;
    private double weightInGrams;
    private string calories;

    public Dough(string flourType, string backingTechnique, double weightInGrams)
    {
        this.WeightInGrams = weightInGrams;
        this.FlourType = flourType;
        this.BackingTechnique = backingTechnique;
    }

    public double WeightInGrams
    {
        get => this.weightInGrams;
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weightInGrams = value;
        }
    }

    public string FlourType
    {
        get => this.flourType;
        private set
        {
            if (!(value.ToLower() == "white" || value.ToLower() == "wholegrain"))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flourType = value.ToLower();
        }
    }

    public string BackingTechnique
    {
        get => this.backingTechnique;
        set
        {
            if (!(value.ToLower() == "chewy" || value.ToLower() == "crispy"
                || value.ToLower() == "homemade"))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.backingTechnique = value.ToLower();
        }
    }

    public double Calories
    {
        get
        {
            double flourMultiplier = 0;
            switch (this.flourType)
            {
                case "white":
                    flourMultiplier = 1.5;
                    break;
                case "wholegrain":
                    flourMultiplier = 1.0;
                    break;
            }

            double bakeTechnique = 0;
            switch (this.backingTechnique)
            {
                case "crispy":
                    bakeTechnique = 0.9;
                    break;
                case "chewy":
                    bakeTechnique = 1.1;
                    break;
                case "homemade":
                    bakeTechnique = 1.0;
                    break;
            }

            return CaloriesPerGram * this.weightInGrams * flourMultiplier * bakeTechnique;

        }

    }

}


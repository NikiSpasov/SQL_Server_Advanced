using System;

public class Kitten : Cat
{
    private const string genderFemale = "Female";

    public Kitten(string name, int age, string gender) 
        : base(name, age, genderFemale)
    {
        this.Gender = genderFemale;
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}


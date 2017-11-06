using System;

public class Tomcat : Cat
{
    private const string genderMale = "Male";

    public Tomcat(string name, int age, string gender)
    : base(name, age, genderMale)
    {
        this.Gender = genderMale;
    }

    public override string ProduceSound()
    {
        return "MEOW";
    }
}


public class Tire
{
    private double pressure;
    private int age;

    public Tire(double pressure, int age)
    {
        this.Pressure = pressure;
        this.Age = age;
    }

    public double Pressure
    {
        get => this.pressure;
        private set => this.pressure = value;
    }

    public int Age
    {
        get => this.age;
        private set => this.age = value;
    }
}


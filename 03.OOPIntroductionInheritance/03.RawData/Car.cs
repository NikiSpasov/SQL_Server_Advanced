using System.Collections.Generic;

public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tire> tires;

    public Car(string model, Engine engine, Cargo cargo)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.tires = new List<Tire>(4);
    }

    public string Model
    {
        get => this.model;
        private set => this.model = value;
    }

    public Engine Engine
    {
        get => this.engine;
        private set => this.engine = value;
    }

    public Cargo Cargo
    {
        get => this.cargo;
        private set => this.cargo = value;
    }

    public List<Tire> Tires
    {
        get => this.tires;
        private set => this.tires = value;
    }

    public void AddTire(Tire tire)
    {
        if (this.Tires.Count < 4)
        {
            this.Tires.Add(tire);
        }
    }

}
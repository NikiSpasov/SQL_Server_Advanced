using System;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionPerKm;
    private double distanceTraveled;

    public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public string Model
    {
        get => this.model;
        private set => this.model = value;
    }

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set => this.fuelAmount = value;
    }

    public double FuelConsumptionPerKm
    {
        get => this.fuelConsumptionPerKm;
        private set => this.fuelConsumptionPerKm = value;
    }

    public double DistanceTraveled
    {
        get => this.distanceTraveled;
        private set => this.distanceTraveled = value;
    }

    public void Drive(double kilometersToDrive)
    {
        if (kilometersToDrive * this.fuelConsumptionPerKm <= FuelAmount)
        {
            this.FuelAmount -= kilometersToDrive * this.FuelConsumptionPerKm;
            this.DistanceTraveled += kilometersToDrive;
            return;
        }
        Console.WriteLine("Insufficient fuel for the drive");

    }
}


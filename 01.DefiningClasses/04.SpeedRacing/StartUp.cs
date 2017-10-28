using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        Dictionary<string, Car> cars = new Dictionary<string, Car>();

        for (int i = 0; i < num; i++)
        {
            string[] args = Console.ReadLine().Split(new[] {' '},
                StringSplitOptions.RemoveEmptyEntries);
            Car currentCar = new Car(
                args[0],
                double.Parse(args[1]),
                double.Parse(args[2])
                );
            cars.Add(args[0], currentCar);
        }
        string input = Console.ReadLine();

        while (input !=  "End")
        {
            string[] args = input.Split(' ');
            string model = args[1];
            double kilometersToDrive = double.Parse(args[2]);

            if (cars.ContainsKey(model))
            {
                cars[model].Drive(kilometersToDrive);
            }
            input = Console.ReadLine();
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:0.00} {car.Value.DistanceTraveled}");
        }
    }
}

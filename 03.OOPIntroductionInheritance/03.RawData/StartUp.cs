using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            var args = Console.ReadLine().Split(new[] {' '},
                StringSplitOptions.RemoveEmptyEntries);
            string carModel = args[0];
            int engineSpeed = int.Parse(args[1]);
            int enginePower = int.Parse(args[2]);
            int cargoWeight = int.Parse(args[3]);
            string typeOfCargo = args[4];
            double tyre1pressure = double.Parse(args[5]);
            int tyre1age = int.Parse(args[6]);
            double tyre2pressure = double.Parse(args[7]);
            int tyre2age = int.Parse(args[8]);
            double tyre3pressure = double.Parse(args[9]);
            int tyre3age = int.Parse(args[10]);
            double tyre4pressure = double.Parse(args[11]);
            int tyre4age = int.Parse(args[12]);

            Cargo currentCargo = new Cargo(cargoWeight, typeOfCargo);
            Engine currEngine = new Engine(engineSpeed, enginePower);
            List<Tire> currentTires = new List<Tire>();

            Car currentCar = new Car(carModel, currEngine, currentCargo);

            Tire tire1 = new Tire(tyre1pressure, tyre1age);
            currentCar.AddTire(tire1);
            Tire tire2 = new Tire(tyre2pressure, tyre2age);
            currentCar.AddTire(tire2);
            Tire tire3 = new Tire(tyre3pressure, tyre3age);
            currentCar.AddTire(tire3);
            Tire tire4 = new Tire(tyre4pressure, tyre4age);
            currentCar.AddTire(tire4);

            cars.Add(currentCar);

        }
        string command = Console.ReadLine();
        if (command == "fragile")
        {
            foreach (var car in cars
                     .Where(x => x.Cargo.Type == command)
                     .Where(y => y.Tires.Average(t => t.Pressure) < 1))
            {
                Console.WriteLine(car.Model);
            }
        }
        else if (command == "flammable")
        {
            
            foreach (var car in cars
                .Where(x => x.Cargo.Type == command)
                .Where(x => x.Engine.Power > 250))
            {
                Console.WriteLine(car.Model);
            }
        }
       
    }
}


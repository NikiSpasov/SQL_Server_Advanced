namespace Cars.App
{
    using System;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    using Cars.Data;
    using Cars.Data.Models;


    public class StartUp
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            using (var context = new CarsDbContext())
            {
               //ResetDatabase(context);

                var cars = context
                    .Cars
                    .Include(c => c.Engine)
                    .Include(c => c.Make)
                    .Include(c => c.LicencePlate)
                    .Include(c => c.CarDealerships)
                    .ThenInclude(x => x.Dealership)
                    .ToArray();

                Console.WriteLine();
 

            }
        }

        private static void ResetDatabase(CarsDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            Seed(context);
        }

        private static void Seed(CarsDbContext context)
        {
            var makes = new[]
            {
                new Make{Name = "Ford"},
                new Make{Name = "Mercedes"},
                new Make{Name = "Audi"},
                new Make{Name = "BMW"},
                new Make{Name = "АЗЛК"},
                new Make{Name = "Лада"},
                new Make{Name = "Трабант"},

            };
            

            var engines = new[]
            {
                new Engine
                {
                    Capacity = 3.0,
                    Cyllinders = 8,
                    FuelType = FuelType.Diesel,
                    HorsePower = 318
                },

                new Engine
                {
                Capacity = 1.2,
                Cyllinders = 3,
                FuelType = FuelType.Gas,
                HorsePower = 60
                },

                new Engine
                {
                    Capacity = 1.6,
                    Cyllinders = 4,
                    FuelType = FuelType.Petrol,
                    HorsePower = 95
                }

            };

            context.Engines.AddRange(engines);

            var cars = new[]
            {
                new Car
                {
                    Engine = engines[2],
                    Make = makes[6],
                    Doors = 4,
                    Model = "Кашон P50",
                    ProductionYear = new DateTime(1958, 1, 1),
                    Trasnmition = Trasnmition.Manual           
                },
                new Car
                {
                    Engine = engines[1],
                    Make = makes[4],
                    Doors = 3,
                    Model = "Москвич-423",
                    ProductionYear = new DateTime(1954, 1, 1),
                    Trasnmition = Trasnmition.Automtaic
                },
                new Car
                {
                    Engine = engines[0],
                    Make = makes[0],
                    Doors = 4,
                    Model = "Escort",
                    ProductionYear = new DateTime(1955, 1, 1),
                    Trasnmition = Trasnmition.Automtaic
                }
            };

            context.Cars.AddRange(cars);

            var dealerships = new[]
            {
                new Dealership
                {
                    Name = "SoftUni-Auto"
                },
                new Dealership
                {
                    Name = "Fast and Furious Auto"
                },
            };

            context.Dealerships.AddRange(dealerships);

            var carDealerships = new CarDealership[]
            {
                new CarDealership
                {
                    Car = cars[0],
                    Dealership = dealerships[0]
                },

                new CarDealership
                {
                    Car = cars[1],
                    Dealership = dealerships[1]
                },
                new CarDealership
                {
                    Car = cars[0],
                    Dealership = dealerships[1]
                }
            };

            context.CarDealerships.AddRange(carDealerships);

            var licencePlates = new[]
            {
                new LicencePlate
                {
                    Number = "СВ1234АБ"
                },
                new LicencePlate
                {
                    Number = "СВ4567БC"
                },
                new LicencePlate
                {
                    Number = "ВР9999AA"
                }
            };

            context.LicencePlates.AddRange(licencePlates);

            context.SaveChanges();
        }
       
    }
}

using System;

public class StartUp
{
    public static void Main()
    {
        try
        {
            string input = Console.ReadLine();
            Dough dough = null;
            Topping currentTopping = null;
            Pizza pizza = new Pizza();

            while (input != "END")
            {
                string[] args = input.Split(new[] {' '},
                    StringSplitOptions.RemoveEmptyEntries);
                if (args[0].ToLower()== "pizza")
                {
                    if (args.Length < 2)
                    {
                        throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                    }
                    pizza.Name = args[1];
                }
                else if (args[0].ToLower() == "dough")
                {
                    dough = new Dough(args[1], args[2], double.Parse(args[3]));
                    pizza.Dough = dough;
                }
                else
                {
                    currentTopping = new Topping(args[1], double.Parse(args[2]));
                    pizza.AddTopping(currentTopping);
                }

                input = Console.ReadLine();
            }           
           
            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:0.00} Calories.");

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}

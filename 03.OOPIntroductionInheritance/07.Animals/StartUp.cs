using System;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        string input = Console.ReadLine();

        while (input != "Beast!")
        {
            try
            {
                Type type = Type.GetType(input);

                string[] args = Console.ReadLine().Split(new[] {' '},
                   StringSplitOptions.RemoveEmptyEntries);

                if (type != null)
                {
                    var animal = (IAnimal) Activator.CreateInstance(type, new object[] {args[0], int.Parse(args[1]), args[2]});

                    Console.WriteLine(animal);
                }

                input = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input!");
                input = Console.ReadLine();
            }
            
        }
    }
}

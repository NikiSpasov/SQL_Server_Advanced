using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        try
        {
            string[] personInput = Console.ReadLine().Split(new[] { '=', ';', ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            if (personInput.Length < 2)
            {
                Console.WriteLine("Name cannot be empty");
                return;
            }

            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < personInput.Length; i += 2)
            {
                Person currentPerson = new Person(personInput[i],
                    double.Parse(personInput[i + 1]));
                persons.Add(currentPerson);
            }

            string[] productInput = Console.ReadLine().Split(new[] { '=', ';', ' '},
                StringSplitOptions.RemoveEmptyEntries);

            if (productInput.Length < 2)
            {
                Console.WriteLine("Name cannot be empty");
                return;
            }

            for (int i = 0; i < personInput.Length; i += 2)
            {
                Product currentProduct = new Product(productInput[i],
                    double.Parse(productInput[i + 1]));
                products.Add(currentProduct);
            }

            string buying = Console.ReadLine();
            while (buying != "END")
            {
                string[] personProduct = buying.Split(new []{' '}, 
                                         StringSplitOptions.RemoveEmptyEntries);
                string personName = personProduct[0];
                string productName = personProduct[1];
                Product product = products.First(y => y.Name == productName);

                var person = persons.First(x => x.Name == personName);
                person?.BuyProduct(product);

                buying = Console.ReadLine();
            }

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

}


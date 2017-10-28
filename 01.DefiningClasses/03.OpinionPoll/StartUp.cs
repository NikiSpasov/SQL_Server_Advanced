using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Person> persons = new List<Person>();

        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            string[] args = Console.ReadLine().Split(' ');
            Person currentPerson = new Person(args[0], int.Parse(args[1]));
            persons.Add(currentPerson);
        }
        foreach (Person person in persons
            .Where(x => x.Age > 30)
            .OrderBy(y => y.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}


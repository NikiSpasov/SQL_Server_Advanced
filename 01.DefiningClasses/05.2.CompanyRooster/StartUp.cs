using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Company_Roster
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            var employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] str = Console.ReadLine().Split();

                string name = str[0];
                decimal salary = decimal.Parse(str[1]);
                string position = str[2];
                string department = str[3];
                string email = "n/a";
                int age = -1;

                if (str.Count() > 4)
                {
                    int error = 0;
                    int.TryParse(str[4], out error);
                    if (error == 0)
                    {
                        email = str[4];
                    }
                    else
                    {
                        age = int.Parse(str[4]);
                    }

                    if (str.Count() > 5)
                    {
                        age = int.Parse(str[5]);
                    }
                }

                employees.Add(new Employee(name, salary, position, department, email, age));

            }

            var maxAvgDepartment = employees
                .GroupBy(e => e.Department)
                .Select(g => new { key = g.Key, Avg = g.Average(e => e.Salary) })
                .OrderByDescending(e => e.Avg).ThenBy(e => e.key)
                .ToDictionary(dp => dp.key, dp => dp.Avg).Keys.First();


            var maxAvgEmployees = employees
                .Where(x => x.Department == maxAvgDepartment)
                .OrderByDescending(x => x.Salary)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {maxAvgDepartment}");

            foreach (var e in maxAvgEmployees)
            {
                Console.WriteLine($"{e.Name} {e.Salary:f2} {e.Email} {e.Age}");
            }
        }
    }
}
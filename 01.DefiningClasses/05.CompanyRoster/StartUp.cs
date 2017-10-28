using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        var deptAndEmployees = new Dictionary<string, List<Employee>>();
        var deptAndSalaries = new Dictionary<string, List<double>>();
        Employee currentEmployee;
        for (int i = 0; i < num; i++)
        {
            string[] args = Console.ReadLine().Split(new[] { ' ' },
                            StringSplitOptions.RemoveEmptyEntries);
            string dept = args[3];
            double salary = double.Parse(args[1]);

            currentEmployee = new Employee
            (
                args[0],
                salary,
                args[2],
                dept
            );

            if (args.Length == 5)
            {
                currentEmployee.Email = args[4];
            }
            else if (args.Length == 6)
            {
                currentEmployee.Email = args[4];
                currentEmployee.Age = int.Parse(args[5]);
            }

            if (deptAndEmployees.ContainsKey(dept))
            {
                deptAndEmployees[dept].Add(currentEmployee);
            }
            else
            {
                deptAndEmployees.Add(dept, new List<Employee>());
                deptAndEmployees[dept].Add(currentEmployee);
            }
           
            if (deptAndSalaries.ContainsKey(dept))
            {
                deptAndSalaries[dept].Add(salary);
                continue;
            }
            deptAndSalaries.Add(dept, new List<double>());
            deptAndSalaries[dept].Add(salary);
        }

        //highest average salary department:
        StringBuilder sb = new StringBuilder();

        string searchedDept = String.Empty;

        foreach (var keyValuePair in deptAndSalaries.OrderByDescending(x => (x.Value.Sum() / x.Value.Count)).Take(1))
        {
            searchedDept = keyValuePair.Key;
            sb.AppendLine($"Highest Average Salary: {keyValuePair.Key}");
        }

        foreach (var employee in deptAndEmployees[searchedDept].OrderByDescending(x => x.Salary))
        {
            sb.AppendLine($"{employee.Name} {employee.Salary:0.00} {employee.Email} {employee.Age}");
        }
   
        Console.WriteLine(sb.ToString().Trim());
    }
}


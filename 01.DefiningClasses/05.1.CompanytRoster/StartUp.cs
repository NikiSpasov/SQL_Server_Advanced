using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        Employee currentEmployee;
        List<Department> departments = new List<Department>();

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
                currentEmployee.AddEmail(args[4]);
            }

            else if (args.Length == 6)
            {
                currentEmployee.AddEmail(args[4]);
                currentEmployee.AddAge(int.Parse(args[5]));
            }
             
            if (departments.Any(x => x.Name == dept))
            {
                var deptAndEmployees = departments
                    .FirstOrDefault(x => x.Name == dept);

                deptAndEmployees?.AddEmployee(currentEmployee);
            }

            else
            {
                var currentDept = new Department(dept);
                currentDept.AddEmployee(currentEmployee);
                departments.Add(currentDept);
            }
        }

        StringBuilder sb = new StringBuilder();

        Department highestAverageDept = departments.OrderByDescending(x => x.AverageSalary).ThenBy(y => y.Name).FirstOrDefault();

        sb.AppendLine($"Highest Average Salary: {highestAverageDept.Name}");
        foreach (var employee in highestAverageDept.Employees.OrderByDescending(x => x.Salary).ThenBy(y=>y.Name))
        {
            sb.AppendLine($"{employee.Name} {employee.Salary:0.00} {employee.Email} {employee.Age}");
        }

        Console.WriteLine(sb.ToString().Trim());
    }
}


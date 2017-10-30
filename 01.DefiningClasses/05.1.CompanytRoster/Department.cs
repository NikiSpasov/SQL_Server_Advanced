using System.Collections.Generic;

public class Department
{
    private string name;

    public List<Employee> Employees;

    public Department(string name)
    {
        this.Employees = new List<Employee>();
        this.Name = name;
    }

    public void AddEmployee (Employee employee)
    {
        this.Employees.Add(employee);
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    private double AverageSalaryMath ()
    {
        double allEmplSalaries = 0;

        foreach (var emp in this.Employees)
        {
            allEmplSalaries += emp.Salary;
        }

        double emplAvg = allEmplSalaries / (this.Employees.Count);

        return emplAvg;
    }

    public double AverageSalary => this.AverageSalaryMath();
}


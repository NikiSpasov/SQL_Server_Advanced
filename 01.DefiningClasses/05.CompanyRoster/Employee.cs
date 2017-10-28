using System.Globalization;

public class Employee
{
    private string name;
    private double salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public Employee()
    {
        
    }

    public Employee(string name, double salary, string position, string department)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Age = -1;
        this.Email = "n/a";
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    } 

    public double Salary
    {
        get => this.salary;
        private set => this.salary = value;
    }

    public string Position
    {
        get => this.position;
        private set => this.position = value;
    }

    public string Department
    {
        get => this.department;
        private set => this.department = value;
    }

    public string Email
    {
        get => this.email;
        set => this.email = value;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }

}
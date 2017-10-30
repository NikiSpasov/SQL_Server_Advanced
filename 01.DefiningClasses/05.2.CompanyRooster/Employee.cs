using System.Globalization;

public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public Employee()
    {
        
    }

    public Employee(string name, decimal salary, string position, string department, string email, int age)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Age = age;
        this.Email = email;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    } 

    public decimal Salary
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
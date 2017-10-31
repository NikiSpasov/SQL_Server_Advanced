using System;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, double workhoursPerDay) 
        : base(firstName, lastName)
    {
        this.weekSalary = weekSalary;
        this.WorkHoursPerDay = workhoursPerDay;
    }

    public decimal WeekSalary
    {
        get => weekSalary;
        private set
        {
            if (value < 11)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        } 
    }

    public double WorkHoursPerDay
    {
        get => workHoursPerDay;
        private set
        {
            if (value > 12 || value < 1)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workHoursPerDay = value;
        } 
    }

    public double SalaryPerHour
    {
        get => (double)this.WeekSalary / 5 / this.WorkHoursPerDay;
    }

    public override string ToString()
    {
       StringBuilder sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}");
        sb.AppendLine($"Last Name: {this.LastName}");
        sb.AppendLine($"Week Salary: {this.WeekSalary:f2}");
        sb.AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}");
        sb.AppendLine($"Salary per hour: {this.SalaryPerHour:f2}");


        return sb.ToString().Trim();
    }
}

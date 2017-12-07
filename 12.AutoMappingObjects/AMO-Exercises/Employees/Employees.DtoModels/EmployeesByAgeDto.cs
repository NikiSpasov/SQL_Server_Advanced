namespace Employees.DtoModels
{
    using System;
    using Employees.Models;

    public class EmployeesByAgeDto
    { 
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? Birthday { get; set; }

        public Employee Manager { get; set; }
    }
}
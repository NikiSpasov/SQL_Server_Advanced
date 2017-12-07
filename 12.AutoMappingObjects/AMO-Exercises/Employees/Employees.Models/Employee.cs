using System;

namespace Employees.Models
{
    using System.Collections.Generic;

    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary  { get; set; }

        public DateTime? Birthday { get; set; }

        public string Address { get; set; }

        public bool HasManager { get; set; } = false;

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}


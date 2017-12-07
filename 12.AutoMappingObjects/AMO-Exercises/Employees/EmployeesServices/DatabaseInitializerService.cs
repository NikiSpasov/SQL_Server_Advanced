namespace Employees.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Employees.Data;
    using Employees.Models;
    using Employees.Services.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly EmployeesDtoDbContext context;

        public DatabaseInitializerService(EmployeesDtoDbContext context)
        {
            this.context = context;
        }

        public void ResetDatabase()
        {

        }

        public void DeleteDatabase()
        {
            this.context.Database.EnsureDeleted();
        }

        public void InitializeDatabase()
        {
            // this.context.Database.EnsureCreated();
            this.context.Database.Migrate();
        }

        public void Seed()
        {
            var employeeList = new List<Employee> {

            new Employee
            {
                FirstName = "Misho",
                LastName = "Petrov",
                Birthday = DateTime.ParseExact("11-24-1980", "MM-dd-yyyy", null),
                Salary = 1000,
                ManagerId = 1
            },
             new Employee()
            {
                FirstName = "Merti",
                LastName = "Setrov",
                Birthday = DateTime.ParseExact("11-25-1981", "MM-dd-yyyy", null),
                Salary = 1001,
                ManagerId = 1
            },
             new Employee()
            {
                FirstName = "Mun4o",
                LastName = "Divotov",
                Birthday = DateTime.ParseExact("11-26-1982", "MM-dd-yyyy", null),
                Salary = 1002
            },
            new Employee
            {
                FirstName = "Pilio",
                LastName = "Petliov",
                Birthday = DateTime.ParseExact("11-27-1983", "MM-dd-yyyy", null),
                Salary = 1003
            },
            new Employee
            {
                FirstName = "Tepaq",
                LastName = "Tapati",
                Birthday = DateTime.ParseExact("11-28-1984", "MM-dd-yyyy", null),
                Salary = 1004
            }};

            this.context.Employees.AddRange(employeeList);
            this.context.SaveChanges();
        }
    }
}

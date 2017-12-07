namespace Employees.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Employees.Data;
    using Employees.DtoModels;
    using Employees.Models;
    using AutoMapper.QueryableExtensions;

    public class EmployeeService
    {
        private readonly EmployeesDtoDbContext context;

        public EmployeeService(EmployeesDtoDbContext context)
        {
            this.context = context;
        }

        public EmployeeDto ById(int employeeId)
        {
            var employee = this.context.Employees.Find(employeeId);

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public void AddEmployee(EmployeeDto dto)
        {
            var employee = Mapper.Map<Employee>(dto);

            this.context.Employees.Add(employee);

            this.context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            var employee = this.context.Employees.Find(employeeId);

            employee.Birthday = date;

            this.context.SaveChanges();
        }

        public string SetAddress(int employeeId, string address)
        {
            var employee = this.context.Employees.Find(employeeId);

            employee.Address = address;

            this.context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }

        public EmployeeDto EmployeeInfo(int employeeId)
        {
            var employee = this.context.Employees.Find(employeeId);

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public EmployeePersonalDto PersonalById(int employeeId)
        {
            var employee = this.context.Employees.Find(employeeId);

            var employeePersonalDto = Mapper.Map<EmployeePersonalDto>(employee);

            return employeePersonalDto;
        }

        //SetManager <employeeId> <managerId>

        public ManagerDto SetManager(int employeeId, int managerId)
        {
            var employee = this.context.Employees.Find(employeeId);

            var manager = this.context.Employees.Find(managerId);

            employee.HasManager = true;

            employee.ManagerId = managerId;

            manager.Employees.Add(employee);

            this.context.SaveChanges();

            var managerDto = Mapper.Map<ManagerDto>(manager);

            return managerDto;
        }

        public ManagerDto ManagerInfo(int employeeId)
        {
            var manager = this.context.Employees.Find(employeeId);

            var managerDto = Mapper.Map<ManagerDto>(manager);

            managerDto.EmployeesCollection = this.context
                .Employees
                .Where(e => e.ManagerId == employeeId)
                .ProjectTo<EmployeeDto>()
                .ToArray();

            return managerDto;
        }

        public List<EmployeesByAgeDto> ListEmployeesOlderThan(int age)
        {
            var yearNow = DateTime.Now.Year;

            var emplByAge = this.context
                .Employees
                .Where(e => (yearNow - e.Birthday.Value.Year) > age)
                .ProjectTo<EmployeesByAgeDto>()
                .ToList();

            return emplByAge.OrderByDescending(e => e.Salary).ToList();

        }
    }
}
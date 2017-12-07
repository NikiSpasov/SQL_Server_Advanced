namespace Employees.App.Core.Commands
{
    using AutoMapper;
    using Employees.App.Core.Commands.Contracts;
    using Employees.Data;
    using Employees.DtoModels;
    using Employees.Models;
    using Employees.Services;
    using Employees.Services.Contracts;

    public class AddEmployeeCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public AddEmployeeCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            string firstName = args[0];
            string lastName = args[1];
            decimal salary = decimal.Parse(args[2]);

            var employeeDto = new EmployeeDto(firstName, lastName, salary);

            employeeService.AddEmployee(employeeDto);

            return $"Employee {firstName} {lastName} successfully added";
        }
    }
}

namespace Employees.App.Core.Commands
{
    using System.Linq;
    using Employees.App.Core.Commands.Contracts;
    using Employees.DtoModels;
    using Employees.Services;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class SetManagerCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetManagerCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            var managerDto = this.employeeService.SetManager(employeeId, managerId);

            string managerName = managerDto.FirstName + " " + managerDto.LastName;

            return $"This employee has a new manager - {managerName}";
        }
    }
}

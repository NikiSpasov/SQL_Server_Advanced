namespace Employees.App.Core.Commands
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Employees.App.Core.Commands.Contracts;
    using Employees.Services;

    public class SetAddressCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetAddressCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);
            string address = String.Join(" ", args.Skip(1));

            var employeeName = this.employeeService.SetAddress(id, address);

            return $"{employeeName}'s address was set to {address}";
        }
    }
}

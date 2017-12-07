using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Core.Commands
{
    using Employees.App.Core.Commands.Contracts;
    using Employees.Services;

    public class ListEmployeesOlderThanCommand : ICommand
    {

        private readonly EmployeeService employeeService;

        public ListEmployeesOlderThanCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        public string Execute(params string[] args)
        {
            int age = int.Parse(args[0]);

            var emplByAgeDto = this.employeeService.ListEmployeesOlderThan(age);

            StringBuilder sb = new StringBuilder();

            foreach (var e in emplByAgeDto)
            {
                string manager = "[no manager]";

                if (e.Manager != null)
                {
                    manager = e.Manager.LastName;
                }
                sb.AppendLine($"{e.FirstName} {e.LastName} - ${e.Salary} - Manager: {manager}");
            }

            return sb.ToString().Trim();
        }
    }
}

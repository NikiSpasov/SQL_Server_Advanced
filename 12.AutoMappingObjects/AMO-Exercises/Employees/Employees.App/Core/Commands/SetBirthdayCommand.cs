namespace Employees.App.Core.Commands
{
    using System;
    using Employees.Services;
    using ICommand = Employees.App.Core.Commands.Contracts.ICommand;

    public class SetBirthdayCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetBirthdayCommand (EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);
            string dateString = args[1];

            DateTime date = DateTime.ParseExact(dateString, "dd-MM-yyyy", null);

            this.employeeService.SetBirthday(id, date);

            return $"Birthdate is set to {dateString}";
        }
    }
}

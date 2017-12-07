namespace Employees.App.Core.Commands
{
    using System;
    using System.Text;
    using Employees.App.Core.Commands.Contracts;
    using Employees.Services;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeePersonalInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);

            var e = this.employeeService.PersonalById(id);

            StringBuilder sb = new StringBuilder();

            string address = e.Address ?? "[no address specified]";

            string birthday = "[no birthday specified]";

            if (e.Birthday != null)
            {
                  birthday = e.Birthday.Value.ToString("dd-MM-yyyy");
            }

            sb.AppendLine($"ID: {e.Id} - {e.FirstName} {e.LastName} - ${e.Salary:F2}");
            sb.AppendLine($"Birthday: {birthday}");
            sb.AppendLine($"Address: {address}");

            return sb.ToString().Trim();
        }
    }
}

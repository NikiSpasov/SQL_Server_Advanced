namespace Employees.App.Core.Commands
{
    using System.Text;
    using Employees.App.Core.Commands.Contracts;
    using Employees.Services;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeeInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);

            var employee = this.employeeService.EmployeeInfo(id);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID: {employee.Id} - {employee.FirstName} {employee.LastName} - ${employee.Salary:F2}");

            return sb.ToString().Trim();
        }
    }
}

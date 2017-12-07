namespace Employees.App.Core.Commands
{
    using System.Text;
    using Employees.App.Core.Commands.Contracts;
    using Employees.Services;

    public class ManagerInfoCommand  :ICommand
    {
        private readonly EmployeeService employeeService;

        public ManagerInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);
            var m = this.employeeService.ManagerInfo(id);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{m.FirstName} {m.LastName} | Employees: {m.CountOfEmployees}");
            foreach (var e in m.EmployeesCollection)
            {
                sb.AppendLine($"    -{e.FirstName} {e.LastName} - ${e.Salary:f2}");
            }

            return sb.ToString().Trim();
        }
    }
}

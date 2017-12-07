namespace Employees.DtoModels
{
    using System.Collections.Generic;

    public class ManagerDto
    { 
        public ICollection<EmployeeDto> EmployeesCollection { get; set; } = new List<EmployeeDto>();

        public ManagerDto() { }

        public ManagerDto(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CountOfEmployees => this.EmployeesCollection.Count;
    }
}

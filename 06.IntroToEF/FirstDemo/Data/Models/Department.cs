namespace FirstDemo.Data.Models
{
    using System.Collections.Generic;

    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }

        public Employee Manager { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}

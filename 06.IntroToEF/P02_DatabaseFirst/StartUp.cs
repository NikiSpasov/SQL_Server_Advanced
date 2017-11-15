namespace P02_DatabaseFirst
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography.X509Certificates;
    using System.Text.RegularExpressions;
    using Microsoft.EntityFrameworkCore;
    using P02_DatabaseFirst.Data;
    using P02_DatabaseFirst.Data.Models;


    public class StartUp
    {
        public static void Main()
        {
            
            using (var db = new SoftUniContext())
            {

                //14. Delete Project by Id:
                var projectId = 2;

                var empProjects = db.EmployeesProjects.Where(ep =>
                    ep.ProjectId == projectId);
                foreach (var ep in empProjects)
                {
                    db.EmployeesProjects.Remove(ep);
                }

                var project = db.Projects.Find(2);
                db.Projects.Remove(project);

                db.SaveChanges();

                var projectsNames = db.Projects.Take(10).Select(p => p.Name);

                foreach (var p in projectsNames)
                {
                    Console.WriteLine($"{p}");
                }

                ////13.	Find Employees by First Name Starting With Sa:
                //Regex regex = new Regex(@"^Sa\w*");

                //foreach (var employee in db.Employees
                //    .Where(x => regex.IsMatch(x.FirstName))
                //    .OrderBy(e => e.FirstName)
                //    .ThenBy(e => e.LastName))
                //{
                //    Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
                //}


                //This is for 12.Increase Salaries:
                //var empl = db.Employees
                //    .Where(
                //        x => x.Department.Name.Equals("Engineering") ||
                //        x.Department.Name.Equals("Tool Design") ||
                //        x.Department.Name.Equals("Marketing") ||
                //        x.Department.Name.Equals("Information Services")
                //    )
                //    //.Select(e => e.Salary + (e.Salary * 12 / 100))
                //    .ToList();

                //foreach (Employee e in empl.OrderBy(x => x.FirstName).ThenBy(y => y.LastName))
                //{
                //    e.Salary += e.Salary * 12 / 100;

                //    Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
                //}
                //db.SaveChanges();



                //This is for 11.Find Latest 10 Projects:
                //var projects = db.Projects
                //               .OrderByDescending( x => x.StartDate)
                //               .Take(10)
                //               .OrderBy(x =>x.Name)
                //               .ToList();

                //foreach (var p in projects)
                //{
                //    Console.WriteLine($"{p.Name}");
                //    Console.WriteLine($"{p.Description}");
                //    Console.WriteLine($"{p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
                //}


                //This is for 10.Departments with More Than 5 Employees
                //var departments = db.Departments
                //                    .Include(d => d.Manager)
                //                    .Include(e => e.Employees)
                //                    .Where(x => x.Employees.Count > 5)
                //                    .OrderBy(x => x.Employees.Count)
                //                    .ThenBy(x => x.Name)
                //                    .ToList();

                //foreach (var dept in departments)
                //{
                //    Console.WriteLine($"{dept.Name} - {dept.Manager.FirstName} {dept.Manager.LastName}");
                //    foreach (var emp in dept.Employees.OrderBy(x => x.FirstName).ThenBy(y => y.LastName))
                //    {
                //        Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                //    }
                //    Console.WriteLine("----------");
                //}



                //This is for 09.Employee 147:
                //var employee =
                //    db.Employees.FirstOrDefault(e => e.EmployeeId == 147);

                //Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

                //var projects = db.EmployeesProjects
                //    .Where(x => x.EmployeeId == 147)
                //    .Include(p => p.Project)
                //    .ToList();

                //foreach (var project in projects.OrderBy(x => x.Project.Name))
                //{
                //    Console.WriteLine(project.Project.Name);
                //}

                //        var emps = db.Employees
                //        .Where(e => e.EmployeesProjects.Any(
                //            ep => ep.Project.StartDate.Year >= 2001 &&
                //                  ep.Project.StartDate.Year <= 2003))
                //        .Take(30)
                //        .Select(e => new
                //        {
                //            Name = $"{e.FirstName} {e.LastName}",
                //            ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                //            Projects = e.EmployeesProjects.Select(ep => new
                //            {
                //                ep.Project.Name,
                //                ep.Project.StartDate,
                //                ep.Project.EndDate
                //            })
                //        })
                //        .ToList();
                //}


                //var emps = db.Employees
                //    .Where(e => e.EmployeesProjects.Any(
                //        ep => ep.Project.StartDate.Year >= 2001 &&
                //              ep.Project.StartDate.Year <= 2003))
                //    .Take(30)
                //    .Select(e => new
                //    {
                //        Name = $"{e.FirstName} {e.LastName}",
                //        ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                //        Projects = e.EmployeesProjects.Select(ep => new
                //        {
                //            ep.Project.Name,
                //            ep.Project.StartDate,
                //            ep.Project.EndDate
                //        })
                //    })
                //    .ToList();
                //foreach (var empl in employee.Where(x => x.EmployeeId == db.EmployeesProjects.))
                //{

                //}
            }




            //7. Employees and Projects

            //using (var db = new SoftUniContext())
            //{
            //    //this is for 07. Emploeey Project
            //    var emps = db.Employees
            //               .Where(e => e.EmployeesProjects.Any(
            //                      ep => ep.Project.StartDate.Year >= 2001 &&
            //                      ep.Project.StartDate.Year <= 2003))
            //        .Take(30)
            //        .Select(e => new
            //        {
            //            Name = $"{e.FirstName} {e.LastName}",
            //            ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
            //            Projects = e.EmployeesProjects.Select(ep => new
            //            {
            //                ep.Project.Name,
            //                ep.Project.StartDate,
            //                ep.Project.EndDate
            //            })
            //        })
            //        .ToList();

            //    foreach (var emp in emps)
            //    {
            //        Console.WriteLine($"{emp.Name} - Manager: {emp.ManagerName}");

            //        foreach (var pr in emp.Projects)
            //        {
            //            Console.Write(
            //                $"--{pr.Name} - {pr.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - ");
            //            if (pr.EndDate == null)
            //            {
            //                Console.WriteLine("not finished");
            //            }
            //            else
            //            {
            //                Console.WriteLine(pr.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt",
            //                    CultureInfo.InvariantCulture));
            //            }
            //        }





            ////This is for 08. AddressByTown
            //var adresses = db.Addresses
            //    .OrderByDescending(x => x.Employees.Count)
            //    .ThenBy(a => a.Town.Name)
            //    .ThenBy(a => a.AddressText)
            //    .Select(a => new {a.AddressText, a.Town.Name, a.Employees.Count})
            //    .Take(10);

            //foreach (var address in adresses)
            //{
            //    Console.WriteLine($"{address.AddressText}, {address.Name} - {address.Count} employees");
            //}



            //This is for 07. Emp&Proj
            //var seslectedEmployees = db.Employees
            //    .OrderByDescending(e => e.AddressId)
            //    .Where(x => x.EmployeeId )
            //    .Take(30)
            //    .Select(e => new {e.FirstName, e.LastName, e.Manager, e.EmployeeId});

            //foreach (var empl in seslectedEmployees)

            //{
            //    Console.WriteLine($"{empl.FirstName} {empl.LastName} - Manager: {empl.Manager.FirstName} {empl.Manager.LastName}");

            //    DateTime startDate = DateTime.Parse("31.12.2000");
            //    DateTime endDate = DateTime.Parse("01.01.2004");

            //    var projects = db.Projects
            //                  .Where(x => x.StartDate > startDate && x.StartDate < endDate)
            //                  .Where(x => x.ProjectId == db.EmployeesProjects.Where(e => e.ProjectId = x.ProjectId));
            //    var projEmpl = new EmployeeProject();

            //}
        }
        // Scaffold-DbContext -Connection "Server=Niki\SqlExpress;Database=SoftUni;Integrated Security=True" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models 
    }

}

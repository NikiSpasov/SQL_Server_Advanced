using System.Linq;
using FirstDemo.Data.Models;


public class StartUp
{
    public static void Main()
    {
        using (var db = new SoftUniDbContext())
        {
            var GGG = db.Towns.SingleOrDefault(t => t.Name == "GGG");

            db.Towns.Remove(GGG);

            var town = new Town()
            {
                Name = "GGG"
            };

            var address = new Address()
            {
                AddressText = "ul. TeTukaTe 3"
            };

            town.Addresses.Add(address);

            db.Towns.Add(town);

            db.SaveChanges(); //very important, it goes to the DB!



            //var employees = db.Employees.Select(e => new
            //{
            //    e.FirstName,
            //    e.LastName,
            //    e.JobTitle
            //})
            //    .GroupBy(y => y.JobTitle)
            //    .OrderBy(x => x.Count());

            //foreach (var group in employees)
            //{
            //    Console.WriteLine($"{group.Key} ({group.Count()})");

            //    foreach (var empl in group)
            //    {
            //        Console.WriteLine($"  {empl.FirstName} {empl.LastName}");
            //    }

            //}

            //var employeeToFire = db.Employees
            //    .Include(e => e.Department)
            //    .FirstOrDefault(x => x.FirstName == "Guy" && x.LastName == "Guilbert");



        }


           
    }
}
//Scaffold-DbContext -Connection "Server=NikiThinkPad\SQLExpress;Database=SoftUni;Integrated security=True" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models -Context SoftUniDbContext
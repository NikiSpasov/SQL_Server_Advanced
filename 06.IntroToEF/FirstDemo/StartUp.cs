using P02_DatabaseFirst.Data;


public class StartUp
{
    public static void Main()
    {
        using (var db = new SoftUniDbContext())
        {

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
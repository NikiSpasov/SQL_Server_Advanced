namespace Employees.App
{
    using System;
    using AutoMapper;
    using Employees.App.Core;
    using Employees.Data;
    using Employees.Services;
    using Employees.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class StartUp
    {
        public static void Main()
        {
            var serviceProvider = ConfigureServices(); // for DInj

            Engine engine = new Engine(serviceProvider);

            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
           var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeesDtoDbContext>(c =>
                c.UseSqlServer(Data.Configuration.ConnectionString));

            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();//here you say: get first and second related 

           // serviceCollection.AddTransient<IEmployeeService, EmployeeService>();
            serviceCollection.AddTransient<EmployeeService>();
            
            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<AutomapperProfile>());
            //this is comfiguration for mapper in the AutomapperProfile class, where the 
            //cinfigurations are held.
            
            var service = serviceCollection.BuildServiceProvider(); //magic! :)

            return service;
        }
    }
}
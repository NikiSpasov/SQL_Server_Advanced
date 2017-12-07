namespace Forum.App
{
    using System;
    using AutoMapper;
    using Forum.Data;
    using Forum.Services;
    using Forum.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    //install Microsoft.Extensions.DependencyInjection package

    //this project is also for AutoMapping, the next chapter!
    //AutoMapper 
    public class StartUp
    {
        public static void Main()
        {
            var serviceProvider = ConfigureServices();

            var engine = new Engine(serviceProvider);

            engine.Run();

            //var userService = serviceProvider.GetService<IUserService>();

            //var userById = userService.ById(5);
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<ForumDbContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IPostService, PostService>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<IReplyService, ReplyService>();

            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<ForumProfile>());

            

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}

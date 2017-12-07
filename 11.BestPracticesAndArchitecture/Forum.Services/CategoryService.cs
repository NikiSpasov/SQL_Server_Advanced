namespace Forum.Services
{
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Forum.Data;
    using Forum.Models;
    using Forum.Services.Contracts;

    public class CategoryService : ICategoryService
    {
        private readonly ForumDbContext context;

        public CategoryService(ForumDbContext context)
        {
            this.context = context;
        }

        public TModel ByName<TModel>(string name)
        {
            var category = this.context
                .Categories
                .Where(cn => cn.Name == name)
                .ProjectTo<TModel>()
                .SingleOrDefault();

            return category;
        }

        public TModel Create<TModel>(string name)
        {
            var category = new Category
            {
                Name = name
            };

            this.context.Categories.Add(category);

            this.context.SaveChanges();

            var dto = AutoMapper.Mapper.Map<TModel>(category);

            return dto;
        }
    }
}

namespace Forum.Services
{
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Forum.Data;
    using Forum.Models;
    using Forum.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

    public class PostService : IPostService
    {
        private readonly ForumDbContext context;

        public PostService(ForumDbContext context)
        {
            this.context = context;
        }

        public TModel Create<TModel>(string title, string content, int categoryId, int authorId)
        {
            var post = new Post
            {
                Title = title,
                Content = content,
                CategoryId = categoryId,
                AuthorId = authorId
            };

            this.context.Posts.Add(post);

            this.context.SaveChanges();

            var dto = AutoMapper.Mapper.Map<TModel>(post);

            return dto;
        }

        public IQueryable<TModel> All<TModel>()
        {
            var posts = this.context.Posts
                .ProjectTo<TModel>();

            return posts;
        }

        public TModel ById<TModel>(int postId)
        {
           var post = this.context.
               Posts
               .Where(p => p.Id == postId)
               .ProjectTo<TModel>()
               .SingleOrDefault();

            var dto = AutoMapper.Mapper.Map<TModel>(post);

            return dto;
        }
    }
}

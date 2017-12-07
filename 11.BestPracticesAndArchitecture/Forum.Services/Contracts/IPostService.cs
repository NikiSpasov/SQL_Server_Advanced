namespace Forum.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Forum.Models;

    public interface IPostService
    {
        TModel Create<TModel>(string title, string content, int categoryId, int authorId);

        IQueryable<TModel> All<TModel>();

        TModel ById<TModel>(int postId);
    }
}

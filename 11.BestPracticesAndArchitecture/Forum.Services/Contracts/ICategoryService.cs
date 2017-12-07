namespace Forum.Services.Contracts
{
    using Forum.Models;

    public interface ICategoryService
    {
        TModel ByName<TModel>(string name);

        TModel Create<TModel>(string name);
    }
}

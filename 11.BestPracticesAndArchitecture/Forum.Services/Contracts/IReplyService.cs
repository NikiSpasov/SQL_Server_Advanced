namespace Forum.Services.Contracts
{
    using Forum.Models;

    public interface IReplyService
    {
        TModel Create<TModel>(string replyText, int postId, int authodId);

        void Delete(int replyId);
    }
}

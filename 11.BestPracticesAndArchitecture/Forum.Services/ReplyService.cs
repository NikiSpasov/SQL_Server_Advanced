namespace Forum.Services
{
    using System;
    using AutoMapper;
    using Forum.Data;
    using Forum.Models;
    using Forum.Services.Contracts;

    public class ReplyService : IReplyService
    {
        private readonly ForumDbContext context;

        public ReplyService(ForumDbContext context)
        {
            this.context = context;
        }

        public TModel Create<TModel>(string replyText, int postId, int authodId)
        {
            var reply = new Reply
            {
                Content = replyText,
                PostId = postId,
                AuthorId = authodId
            };

            this.context.Replies.Add(reply);

            this.context.SaveChanges();

            var replyDto = Mapper.Map<TModel>(reply);

            return replyDto;
        }

        public void Delete(int replyId)
        {
            throw new NotImplementedException();
        }
    }
}

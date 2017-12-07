namespace Forum.App.Commands
{
    using System;
    using System.Runtime.CompilerServices;
    using Forum.App.Commands.Contracts;
    using Forum.Models;
    using Forum.Services.Contracts;

    public class ReplyCommand : ICommand
    {
        private readonly IReplyService replyService;

        public ReplyCommand(IReplyService replyService)
        {
            this.replyService = replyService;
        }

        public string Execute(params string[] arguments)
        {

            var postId = int.Parse(arguments[0]);
            var content = arguments[1];

            if (Session.User == null)
            {
                return "You are not logged in!";
            }

            var authorId = Session.User.Id;

            this.replyService.Create<Reply>(content, postId, authorId);

            return "Reply created successfully";
        }
    }
}

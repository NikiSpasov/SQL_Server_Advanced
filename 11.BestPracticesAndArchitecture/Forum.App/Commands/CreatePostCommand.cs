namespace Forum.App.Commands
{
    using System.ComponentModel.DataAnnotations;
    using Forum.App.Commands.Contracts;
    using Forum.Models;
    using Forum.Services.Contracts;

    public class CreatePostCommand : ICommand
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        private readonly IUserSessionService userSessionService;

        public CreatePostCommand(IPostService postService, ICategoryService categoryService, IUserSessionService userSessionSessionService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
            this.userSessionService = userSessionSessionService;
        }

        public string Execute(params string[] arguments)
        {

            var categoryName = arguments[0];
            var postTitle = arguments[1];
            var postContent = arguments[2];

            if (Session.User == null)
            {
                return "You are not logged in!";
            }

            var category = this.categoryService.ByName<Category>(categoryName);

            if (category == null)
            {
                category = this.categoryService.Create<Category>(categoryName);
            }

            var authorId = this.userSessionService.User.Id;
            var categoryId = category.Id;

            var post = this.postService.Create<Post>(postTitle, postContent, categoryId, authorId);

            return $"Post with id {post.Id} created successfully!";
        }
    }
}

namespace Forum.App.Commands
{
    using System.Linq;
    using System.Text;
    using Forum.App.Commands.Contracts;
    using Forum.App.Models;
    using Forum.Services.Contracts;
    using AutoMapper.QueryableExtensions;
    public class ListPostsCommand : ICommand
    {
        private IPostService postService;

        public ListPostsCommand(IPostService postService)
        {
            this.postService = postService;
        }

        public string Execute(params string[] arguments)
        {
            var posts = this.postService
                .All<PostDto>()
                .GroupBy(p => p.CategoryName)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var group in posts)
            {
                var categoryName = group.Key;

               sb.AppendLine(categoryName + ":");

                foreach (var p in group)
                {
                    sb.AppendLine($"  {p.Id}. {p.Title} - {p.Content} by {p.AuthorUsername}");          
                }
            }

            return sb.ToString().Trim();
        }
    }
}

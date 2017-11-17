namespace Forum.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class Post
    {
        private string v;
        private User user;

        public Post()
        {
            
        }

        public Post(string title, string content, Category category, User author)
        {
            this.Title = title;
            this.Content = content;
            this.Category = category;
            this.Author = author;
        }

        public Post(string title, string content, int categoryId, int authorId)
        {
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.AuthorId = authorId;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public int CategoryId { get; set; }
 
        public Category Category { get; set; }

        public ICollection<Reply> Replies { get; set; }

        public ICollection<PostTag> PostTags { get; set; }

    }
}

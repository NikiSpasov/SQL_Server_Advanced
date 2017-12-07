namespace Forum.Models
{
    using System.Collections.Generic;

    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}
    
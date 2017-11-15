namespace Forum.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public User AuthorUser { get; set; }

        public ICollection<Reply> Replies { get; set; }
    }
}

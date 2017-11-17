﻿namespace Forum.Data.Models
{
    using System.Net.Mime;

    public class Reply
    {
        public Reply()
        {
            
        }

        public Reply(string content, Post post, User author)
        {
            this.Content = content;
            this.Post = post;
            this.Author = author;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public int AuthodId { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }

        public User Author { get; set; }
    }
}

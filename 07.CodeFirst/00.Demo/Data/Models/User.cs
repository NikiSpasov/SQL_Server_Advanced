namespace Forum.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class User
    {
        public int  Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}

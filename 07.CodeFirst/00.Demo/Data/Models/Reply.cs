namespace Forum.Data.Models
{
    using System.Net.Mime;

    public class Reply
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int AuthodId { get; set; }

        public User Author { get; set; }
    }
}

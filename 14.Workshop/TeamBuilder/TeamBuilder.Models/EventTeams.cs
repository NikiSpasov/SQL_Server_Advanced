namespace TeamBuilder.Models
{
    public class EventTeams
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

    }
}

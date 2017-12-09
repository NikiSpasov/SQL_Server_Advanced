namespace TeamBuilder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //[MinLength(3)]
        public string Acronym { get; set; }

        public User Creator { get; set; }
        public int CreatorId { get; set; }

        public int InvitationId { get; set; }

        public ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();
        public ICollection<EventTeams> EventTeams { get; set; } = new List<EventTeams>();
        public ICollection<UserTeams> UserTeams { get; set; } = new List<UserTeams>();
    }
}

using System;

namespace TeamBuilder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class User
    {
        private string password;

        public int Id { get; set; }

        [MinLength(3), MaxLength(25)]
        public string Username { get; set; }

        [MinLength(6), MaxLength(30)]
        public string Password
        {
            get => this.password;
            set
            {
                if (!value.Any(char.IsDigit))
                {
                    throw new ArgumentException("There must have a digit!");
                }
                if (!value.Any(char.IsUpper))
                {
                    throw new ArgumentException("There must have an uppercase letter!");
                }
                this.password = value;
            }
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public bool IsDeleted { get; set; }

        public int InvitationId { get; set; }

        public Invitation Invitation { get; set; }


        public ICollection<Event> CreatedEvents { get; set; } = new List<Event>();
    
       // public ICollection<UserTeams> UserTeams { get; set; } = new List<UserTeams>();

        public ICollection<UserTeams> CreatedUserTeams { get; set; } = new List<UserTeams>();

        public ICollection<Invitation> RecievedInvitations { get; set; } = new List<Invitation>();

        //public ICollection<Team> CreatedTeams { get; set; } = new List<Team>();

    }
}

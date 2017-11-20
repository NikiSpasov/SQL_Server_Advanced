﻿namespace P03_FootballBetting.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }

        public ICollection<Bet> Bets { get; set; } = new List<Bet>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

public class FootballTeam
{
    private string name;
    private Dictionary<string, Player> players;

    public FootballTeam(string name)
    {
        this.Name = name;
        this.players = new Dictionary<string, Player>();
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public int Rating
    {
        get
        {
            int rating = 0;
            foreach (var player in this.players)
            {
                rating += player.Value.OverallSkill;
            }
            return rating;
        }
    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player.Name, player);
    }

    public void RemovePlayer(string playerName)
    {
        if (!this.players.ContainsKey(playerName))
        {
            Console.WriteLine($"Player {playerName} is not in {this.name} team.");
            return;
        }

        this.players.Remove(playerName);

    }
}


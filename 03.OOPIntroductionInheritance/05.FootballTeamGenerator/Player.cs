using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;
    private int overallSkill;

    private const int MinStat = 0;
    private const int MaxStat = 100;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.endurance = endurance;
        this.sprint = sprint;
        this.dribble = dribble;
        this.passing = passing;
        this.shooting = shooting;
    }

    public static Player CreateInstance(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("A name should not be empty.");
            return null;
        }
        if (endurance < MinStat || endurance > MaxStat)
        {
            Console.WriteLine("Endurance should be between 0 and 100.");
            return null;
        }
        if (sprint < MinStat || sprint > MaxStat)
        {
            Console.WriteLine("Sprint should be between 0 and 100.");
            return null;
        }
        if (dribble < MinStat || dribble > MaxStat)
        {
            Console.WriteLine("Dribble should be between 0 and 100.");
            return null;
        }
        if (passing < MinStat || passing > MaxStat)
        {
            Console.WriteLine("Passing should be between 0 and 100.");
            return null;
        }
        else if (shooting < MinStat || shooting > MaxStat)
        {
            Console.WriteLine("Shooting should be between 0 and 100.");
            return null;
        }
        return new Player(name, endurance, sprint, dribble, passing, shooting);
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public int OverallSkill
    {
        get
        {
            List<int> overallSkill = new List<int>();
            overallSkill.Add(this.endurance);
            overallSkill.Add(this.dribble);
            overallSkill.Add(this.passing);
            overallSkill.Add(this.shooting);
            overallSkill.Add(this.sprint);
            var average = Math.Ceiling(overallSkill.Select(s => s).Average());
            return (int)average;
        }
    }
}



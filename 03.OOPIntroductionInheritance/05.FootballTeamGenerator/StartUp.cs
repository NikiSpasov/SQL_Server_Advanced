using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        try
        {
            string input = Console.ReadLine();

            Dictionary<string, FootballTeam> teams = new Dictionary<string, FootballTeam>();

            while (input != "END")
            {
                string[] args = input.Split(new []{';'}, 
                                StringSplitOptions.RemoveEmptyEntries);

                switch (args[0])
                {
                    case "Team":
                        teams.Add(args[1], new FootballTeam(args[1]));
                        break;

                    case "Add":
                        if (!teams.ContainsKey(args[1]))
                        {
                            Console.WriteLine($"Team {args[1]} does not exist.");
                            break;
                        }

                        Player playerToBeAdded = Player.CreateInstance(
                            args[2],
                            int.Parse(args[3]),
                            int.Parse(args[4]),
                            int.Parse(args[5]),
                            int.Parse(args[6]),
                            int.Parse(args[7])
                            );

                        if (playerToBeAdded != null)
                        {
                            teams[args[1]].AddPlayer(playerToBeAdded);
                        }                    
                        break;

                    case "Remove":
                        if (!teams.ContainsKey(args[1]))
                        {
                            Console.WriteLine($"Team {args[1]} does not exist.");
                            break;
                        }
                        teams[args[1]].RemovePlayer(args[2]);
                        break;

                    case "Rating":
                        if (!teams.ContainsKey(args[1]))
                        {
                            Console.WriteLine($"Team {args[1]} does not exist.");
                            break;
                        }
                        Console.WriteLine($"{teams[args[1]].Name} - { teams[args[1]].Rating}");
                        break;
                }

                input = Console.ReadLine();
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}

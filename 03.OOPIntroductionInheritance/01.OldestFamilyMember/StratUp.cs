using System;
using System.Reflection;

public class StratUp
{
    public static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        int num = int.Parse(Console.ReadLine());
        Family family = new Family();
        for (int i = 0; i < num; i++)
        {
            string[] args = Console.ReadLine().Split(' ');
            Person currentPerson = new Person(args[0], int.Parse(args[1]));
            family.AddMember(currentPerson);

        }
        Console.WriteLine(family.GetOldestMember().ToString());

    }
}


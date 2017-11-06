using System;

public class StartUp
{
    public static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        DateModifier dateMod = new DateModifier(firstDate, secondDate);

        Console.WriteLine(dateMod.GetTimeDiff());

    }
}


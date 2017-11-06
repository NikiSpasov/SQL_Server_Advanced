using System;
using System.Linq;

public class DateModifier
{
    private string fistDate;
    private string secondDate;

    public DateModifier(string fistDate, string secondDate)
    {
        this.FistDate = fistDate;
        this.SecondDate = secondDate;
    }

    public string FistDate
    {
        get => this.fistDate;
        private set => this.fistDate = value;
    }

    public string SecondDate
    {
        get => this.secondDate;
        private set => this.secondDate = value;
    }

    public int GetTimeDiff()
    {
        int[] firstArgs = 
            this.fistDate.Split(' ')
            .Select(int.Parse)
            .ToArray();

        DateTime firstDate = new DateTime(firstArgs[0], firstArgs[1], firstArgs[2]);

        int[] secondArgs =
            this.secondDate.Split(' ')
                .Select(int.Parse)
                .ToArray();
        DateTime secondDate = new DateTime(secondArgs[0], secondArgs[1], secondArgs[2]);

        //var timeSpan = new TimeSpan();
        //var a = timeSpan. (fistDate, secondDate);
        return Math.Abs((int)(firstDate - secondDate).TotalDays);
    }
}

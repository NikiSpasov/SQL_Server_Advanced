using System;
using System.Text.RegularExpressions;

public class Song
{
    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.artistName = artistName;
        this.songName = songName;
        this.minutes = minutes;
        this.seconds = seconds;
    }

    public int TotalTimeInSeconds
    {
        get
        {
            int minutesInSeconds = this.minutes * 60;
            return minutesInSeconds + this.seconds;
        }
    }


    public static Song CreateInstance(string artistName, string songName, string sognLenght)
    {
        int minutes;
        int seconds;

        if (artistName.Length < 3 || artistName.Length > 20)
        {
            throw new ArgumentException($"{ExeptionMessages.InvalidArtistNameException}");
        }

        if (songName.Length < 3 || songName.Length > 20)
        {
            throw new ArgumentException($"{ExeptionMessages.InvalidSongNameException}");
        }

        Regex regex = new Regex(@"^\d+:\d+$");
        if (regex.IsMatch(sognLenght))
        {
            string[] time = sognLenght.Split(':');
            minutes = int.Parse(time[0]);
            seconds = int.Parse(time[1]);
            if (minutes < 0 || minutes > 14)
            {
                throw new ArgumentException($"{ExeptionMessages.InvalidSongMinutesException}");
            }
            if (seconds < 0 || seconds > 59)
            {
                throw new ArgumentException($"{ExeptionMessages.InvalidSongSecondsException}");
            }

        }
        else
        {
            throw new ArgumentException($"{ExeptionMessages.InvalidSongLengthException}");
        }

        return new Song(artistName, songName, minutes, seconds);
    }
}


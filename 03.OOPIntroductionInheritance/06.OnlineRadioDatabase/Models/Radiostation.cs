using System.Collections.Generic;
using System.Linq;

public class Radiostation
{
    private List<Song> playlist;

    public Radiostation()
    {
      this.playlist = new List<Song>();  
    }

    public void AddSong(Song song)
    {
        this.playlist.Add(song);
    }

    public int SongAdded => this.playlist.Count;

    public string PlaylistLenght
    {
        get
        {
            var totalSeconds = this.playlist.Sum(x => x.TotalTimeInSeconds);
            var minutes = 0;
            var seconds = totalSeconds;

            if (seconds >= 60)
            {
                minutes = seconds / 60;                
            }

            var hours = 0;
            if (minutes >= 60)
            {
                hours = minutes / 60;
                minutes -= hours * 60;
            }

            seconds -= (hours * 60 * 60 + minutes * 60);

            return $"{hours}h {minutes}m {seconds}s";
        }

       

    }
}


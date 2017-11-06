using System;

public class StartUp
{
    public static void Main()
    {
        Radiostation radiostation = new Radiostation();

        int num = int.Parse(Console.ReadLine());

        for (int i = 0; i < num; i++)
        {
            try
            {
                string[] args = Console.ReadLine().Split(new[] { ';' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (args.Length != 3)
                {
                    throw new ArgumentException($"{ExeptionMessages.InvalidSongException}");
                }

                string artistName = args[0];
                string songName = args[1];
                string songLenght = args[2];

                Song currentSong = Song.CreateInstance(songName, artistName, songLenght);

                if (currentSong != null)
                {
                    radiostation.AddSong(currentSong);
                    Console.WriteLine("Song added.");
                }
            }
            catch (Exception e)
            {
                if (e.Message == ExeptionMessages.InvalidSongException)
                {
                    Console.WriteLine(e);
                    return;
                }
                Console.WriteLine(e.Message);
            }

        }
        Console.WriteLine($"Songs added: {radiostation.SongAdded}");
        Console.WriteLine($"Playlist length: {radiostation.PlaylistLenght}");
    }

}


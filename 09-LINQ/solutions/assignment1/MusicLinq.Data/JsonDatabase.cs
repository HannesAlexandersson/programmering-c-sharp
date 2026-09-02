using System.Text.Json;

namespace MusicLinq.Data
{
    public class JsonDatabase
    {
        public List<Artist> Artists { get; set; } = new List<Artist>();
        public List<Genre> Genres { get; set; } = new List<Genre>();

        public static JsonDatabase Load()
        {
            var json = File.ReadAllText("database.json");

            return JsonSerializer.Deserialize<JsonDatabase>(json);
        }
    }

    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; }

        public override string ToString() => Name;
    }

    public class Album
    {
        public int AlbumID { get; set; }
        public int ArtistID { get; set; }
        public string Title { get; set; }
        public List<Track> Tracks { get; set; } = new List<Track>();

        public override string ToString() => Title;
    }

    public class Artist
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public List<Album> Albums { get; set; } = new List<Album>();

        public override string ToString() => Name;
    }

    public class Track
    {
        public int TrackID { get; set; }
        public int AlbumID { get; set; }
        public int GenreID { get; set; }
        public string Name { get; set; }
        public int Bytes { get; set; }
        public int Milliseconds { get; set; }

        public override string ToString() => Name;
    }
}

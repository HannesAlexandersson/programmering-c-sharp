using MusicLinq.Data;

JsonDatabase Database = JsonDatabase.Load();

Exercise1();
Exercise2();
Exercise3();
Exercise4();
Exercise5();
Exercise6();
Exercise7();
Exercise8();
Exercise9();
Exercise10();
Exercise11();
Exercise12();
Exercise13("Queen");

void Exercise1()
{
    Database.Artists
        .Where(x => x.Name.StartsWith('D'))
        .OrderBy(x => x.Name)
        .Select(x => x.Name)
        .Output();
}

void Exercise2()
{
    Database.Artists
        .Where(x => x.Albums.Count > 5)
        .Select(x => x.Name)
        .Output();
}

void Exercise3()
{
    Database.Artists
        .Where(x => x.Name.Length <= 4)
        .OrderBy(x => x.Name)
        .Select(x => x.Name)
        .Output();
}
void Exercise4()
{
    Database.Artists
        .SelectMany(x => x.Albums)
        .Where(x => x.Tracks.Count == 2)
        .Output();
}

void Exercise5()
{
    Database.Artists
        .SelectMany(x => x.Albums)
        .SelectMany(x => x.Tracks)
        .Count()
        .Output();
}

void Exercise6()
{
    Database.Artists
        .SelectMany(x => x.Albums)
        .SelectMany(x => x.Tracks)
        .Select(x => x.Name)
        .Distinct()
        .Count()
        .Output();
}

void Exercise7()
{
    Database.Artists
        .SelectMany(x => x.Albums)
        .SelectMany(x => x.Tracks)
        .Average(x => x.Bytes)
        .Output(x => $"{(int)x} bytes");
}

void Exercise8()
{
    Database.Artists
        .Where(x => x.Name == "Various Artists")
        .SelectMany(x => x.Albums)
        .Select(x => x.Title)
        .Output();
}

void Exercise9()
{
    Database.Artists
        .SelectMany(x => x.Albums)
        .SelectMany(x => x.Tracks)
        .Sum(x => x.Milliseconds)
        .Output(x => $"{x / 1000 / 3600}");
}

void Exercise10()
{
    Database.Artists
        .OrderByDescending(x => x.Albums.Count)
        .Take(10)
        .Output();
}


void Exercise11()
{
    Database.Artists
        .SelectMany(x => x.Albums)
        .SelectMany(x => x.Tracks)
        .OrderByDescending(x => x.Milliseconds)
        .First()
        .Output(x => $"{x.Name} ({x.Milliseconds / 1000 / 60} minutes)");
}


void Exercise12()
{
    Database.Artists.SelectMany(x => x.Albums.SelectMany(y => y.Tracks))
        .Where(x => x.Name.Contains("Yesterday"))
        .Output(x => $"{x.Name} ({x.Milliseconds / 1000 / 60:D2}:{x.Milliseconds / 1000 % 60:D2})");
}


void Exercise13(string artistName)
{
    var artist = Database.Artists.First(x => x.Name == artistName);

    Console.WriteLine($"Artist: {artistName}");
    Console.WriteLine($"Albums: {artist.Albums.Count} albums in database");

    foreach (var album in artist.Albums)
    {
        var tracks = album.Tracks;

        Console.WriteLine($"  {album.Title}");

        for (int i = 0; i < tracks.Count; i++)
        {
            Console.WriteLine($"    {i + 1:D2}. {tracks[i]}");
        }
    }
}


// This is the kind of silly things you can do in C#, it's a small
// extension Henrik (The king of YRGO-C#) wrote to cut down on the amount of repetitive
// typing for printing the results.
static class OutputExtension
{
    public static void Output<T>(this T result, Func<T, string>? format = null) =>
        Console.WriteLine(format == null ? result!.ToString() : format(result));

    public static void Output<T>(this IEnumerable<T> result, Func<T, string>? format = null) =>
        result.ToList().ForEach(item => Output(item, format));
}

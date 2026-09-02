var mapValues = File.ReadAllLines("map.txt");

var landTiles = CalculateLandTilesInMap(mapValues);
Console.WriteLine($"Number of tiles with land: {landTiles}");

int CalculateLandTilesInMap(string[] map)
{
    var result = 0;
    foreach (var row in map)
    {
        foreach (var tile in row)
        {
            result += tile == '#' ? 1 : 0;
        }
    }

    return result;
}

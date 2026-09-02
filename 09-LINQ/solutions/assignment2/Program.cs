using Assignment2;

var map = File.ReadAllLines("map.txt");
var reader = new MapReader(map);
var result = reader.CountShorelines();

Console.WriteLine($"Meters of shoreline in map: {result * 10}");

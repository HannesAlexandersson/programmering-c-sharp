// See https://aka.ms/new-console-template for more information

// generate a random color

using Assignment7;

var random = new Random();

while (true)
{
    var x = random.Next(0, Console.WindowWidth);
    var y = random.Next(0, Console.WindowHeight);
    var width = random.Next(1, Console.WindowWidth - x);
    var height = random.Next(1, Console.WindowHeight - y);
    var box = new Box
    {
        X = x,
        Y = y,
        Width = width,
        Height = height
    };

    var color  = (ConsoleColor)random.Next(1, 16);

    box.Draw(color);
    Thread.Sleep(random.Next(0, 100));
}

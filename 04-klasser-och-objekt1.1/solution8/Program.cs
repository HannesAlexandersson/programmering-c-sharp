using Assignment8;

var random = new Random();
var game = new Game();
var computer = new Computer();

game.Correct = random.Next(1, 100);

Console.WriteLine("Human vs Computer");

while (true)
{
    Console.WriteLine();
    var guess = GetInteger("You guess the number: ");
    var result = game.GuessNumber(guess);

    if (result == 0)
    {
        Console.WriteLine("that is correct, a winner is you");
        break;
    }

    computer.Update(result, guess);

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine();
    Console.WriteLine($"Computer will guess between: {computer.Low} - {computer.High}");
    Console.WriteLine();
    Console.ResetColor();

    guess = random.Next(computer.Low, computer.High + 1);

    Console.WriteLine($"Computer guess the number: {guess}");

    result = game.GuessNumber(guess);

    if (result == 0)
    {
        Console.WriteLine("that is correct, all hail the mighty machine! SKYTNET LIVES!");
        break;
    }

    computer.Update(result, guess);
}

int GetInteger(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var answer = Console.ReadLine();
        if (int.TryParse(answer, out var result))
        {
            return result;
        }
        Console.WriteLine("that is not a number");
    }
}

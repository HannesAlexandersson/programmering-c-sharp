using Assignment3;

var megatron = new Robot("Megatron", 10);
var optimus  = new Robot("Optimus Prime", 10);

var game = new RobotFightingGame(megatron, optimus);

// play the game until someone wins
while (!game.GameOver)
{
    game.NextRound();
    Thread.Sleep(400);
}

if (game.Winner == null)
{
    Console.WriteLine("The game ends in a draw! What a disappointment!");
}
else
{
    Console.WriteLine($"{game.Winner} is the winner!");
}

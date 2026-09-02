// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to Amazing Ticket Systems 1.0");
Console.WriteLine();
string answer;

while (true)
{
    Console.WriteLine("Which ticket would you like?");
    Console.Write("Type A, B or C:");
    answer = Console.ReadLine().ToUpper();

    if (answer == "A" || answer == "B" || answer == "C")
    {
        break;
    }

    Console.WriteLine("I'm sorry, that's not a valid ticket.");
}

var price = 0;

if (answer == "A")
{
    price = 33;
}

if (answer == "B")
{
    price = 40;
}

if (answer == "C")
{
    price = 60;
}

Console.WriteLine($"You have selected {answer}, your total is ${price}");

var number = GetInteger("Please type a number: ");

Console.WriteLine($"Your number is {number}.");

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
    }
}

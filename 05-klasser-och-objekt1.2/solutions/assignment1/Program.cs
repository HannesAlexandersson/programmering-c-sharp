for (var i = 1; i <= 100; i++)
{
    if (i % 15 == 0)
    {
        Console.WriteLine("FizzBuzz");
        continue;
    }

    if (i % 5 == 0)
    {
        Console.WriteLine("Buzz");
        continue;
    }

    if (i % 3 == 0)
    {
        Console.WriteLine("Fizz");
        continue;
    }

    Console.WriteLine(i);
}

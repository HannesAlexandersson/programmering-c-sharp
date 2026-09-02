// Assignment 1

﻿var random = new Random();
var correctNumber = random.Next(1, 100);

while (true)
{
    var guess = GetInteger("Guess a number: ");

    if (guess < correctNumber)
    {
        Console.WriteLine("too low");
        continue;
    }

    if (guess > correctNumber)
    {
        Console.WriteLine("too high");
        continue;
    }

    if (guess == correctNumber)
    {
        Console.WriteLine("that is correct");
        break;
    }
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

// ASSIGNMENT 2

var random = new Random();
var correctNumber = random.Next(1, 101);

var i = 0;
while (i < 3)
{
    i++;
    var guess = GetInteger($"[{i}/3] Guess a number: ");

    if (guess < correctNumber)
    {
        Console.WriteLine("too low");
        continue;
    }

    if (guess > correctNumber)
    {
        Console.WriteLine("too high");
        continue;
    }

    if (guess == correctNumber)
    {
        Console.WriteLine("that is correct");
        return;
    }
}

Console.WriteLine("GAME OVER");

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

// ASSIGNMENT 3

﻿var firstname = Normalize("GUYBRUSH");
var lastname = Normalize("threepwood");

Console.WriteLine($"{firstname} {lastname}");

string Normalize(string s)
{
    var start = s.Substring(0, 1).ToUpper();
    var end = s.Substring(1).ToLower();

    return start + end;
}

string NormalizeWithRange(string s)
{
    var start = s[..1].ToUpper();
    var end = s[1..].ToLower();

    return start + end;
}

string NormalizeWithMath(string s)
{
    var chars = new char[s.Length];
    for (var i = 0; i < s.Length; i++)
    {
        var l = s[i];
        if (l < 97)
        {
            l = (char)(l + 32);
        }

        if (i == 0)
        {
            l = (char)(l - 32);
        }

        chars[i] = l;
    }

    return new string(chars);
}

// ASSIGNMENT 4

﻿var input = "4719";
var value = SumAllDigits(input);

Console.WriteLine($"Sum of {input} = {value}");

int SumAllDigits(string s)
{
    var sum = 0;

    for (var i = 0; i < s.Length; i++)
    {
        var text = s.Substring(i, 1);

        int.TryParse(text, out var digit);

        sum += digit;
    }

    return sum;
}

int SumAllDigitsWithMagic(string s)
{
    var sum = 0;

    for (var i = 0; i < s.Length; i++)
    {
        var digit = s[i];
        sum += digit - '0'; // You can't count with strings, but you can count with char :)
    }

    return sum;
}

// ASSIGNMENT 5
﻿Console.Write("What is your name? ");
var name = Console.ReadLine();

for (var i = 0; i < name.Length; i++)
{
    for (int j = 0; j < name.Length; j++)
    {
        Console.Write(name[i].ToString().ToUpper());
    }
    Console.Write(Environment.NewLine);
}

// ASSIGNMENT 6
﻿Console.WriteLine(IsValidPassword("short"));
Console.WriteLine(IsValidPassword("password"));
Console.WriteLine(IsValidPassword("12345678"));
Console.WriteLine(IsValidPassword("xxxxxxx0"));
Console.WriteLine(IsValidPassword("p4ssw0rd"));

bool IsValidPassword(string input)
{
    if (!HasMinimumLength(input, 8))
    {
        return false;
    }

    if (!HasNonDigits(input))
    {
        return false;
    }

    if (!HasAtLeastTwoDigits(input))
    {
        return false;
    }

    return true;
}

bool HasMinimumLength(string input, int length)
{
    return input.Length >= length;
}

bool HasNonDigits(string input)
{
    for (var i = 0; i < input.Length; i++)
    {
        if (!char.IsDigit(input, i))
        {
            return true;
        }
    }

    return false;
}

bool HasAtLeastTwoDigits(string input)
{
    var digits = 0;

    for (var i = 0; i < input.Length; i++)
    {
        if (char.IsDigit(input, i))
        {
            digits++;
        }
    }

    return digits >= 2;
}

// ASSIGNMENT 7
﻿var size = GetInteger("Please input the size of your Christmas tree: ");

Console.ForegroundColor = ConsoleColor.Green;

for (var i = 0; i < size; i++)
{
    Console.Write(new string(' ', size - i));
    var stars = i * 2 + 1;
    Console.Write(new string('*', stars));
    Console.WriteLine();
}

Console.ForegroundColor = ConsoleColor.DarkYellow;

Console.Write(new string(' ', size - 1));
Console.Write("[ ]");
Console.WriteLine();

Console.ResetColor();

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
        Console.WriteLine("That is not a number!");
    }
}

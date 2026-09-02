// Assignment 1
﻿var average = GetAverage(5, 10, 7.4);

Console.WriteLine($"Average: {average:F2}");

double GetAverage(double value1, double value2, double value3)
{
    return (value1 + value2 + value3) / 3;
}

/* -------------------- */
// Assignment 2

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

/* -------------------- */
// Assignment 3

var number = GetInteger("Please type a number between 1-2000: ", 1, 2000);

Console.WriteLine($"Your number is {number}.");

int GetInteger(string prompt, int min, int max)
{
    while (true)
    {
        Console.Write(prompt);
        var answer = Console.ReadLine();
        if (int.TryParse(answer, out var result) &&
            result >= min &&
            result <= max)
        {
            return result;
        }
    }
}

/* -------------------- */
// Assignment 4

﻿var x = GetInteger("Please input the value for X:");
var y = GetInteger("Please input the value for y:");

var total = x + y;
var answerTotal = GetInteger($"What is the sum of {x} + {y}? ");

if (answerTotal == total)
{
    Console.WriteLine($"{answerTotal} is correct!");
}
else
{
    Console.WriteLine("No, I don't tink så!");
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
    }
}

/* -------------------- */
// Assignment 5

﻿Console.WriteLine($"Buying 8 units at $10:- costs ${CalculatePrice(8, 10)}");
Console.WriteLine($"Buying 16 units at $10:- costs ${CalculatePrice(16, 10)}");
Console.WriteLine($"Buying 28 units at $35:- costs ${CalculatePrice(28, 35)}");

int CalculatePrice(int amount, int price)
{
    var total = price * amount;
    var freeAmount = amount / 10;

    return total - (freeAmount * price);
}


/* -------------------- */
// Assignment 6

﻿Console.WriteLine("-- Amazing Leap Year Calculator --");
var firstYear = GetInteger("First year: ", 0, 9999);
var secondYear = GetInteger("Second year: ", firstYear, 9999);

for (var year = firstYear; year <= secondYear; year++)
{
    if (DateTime.IsLeapYear(year))
    {
        Console.WriteLine($"{year} *");
    }
    else
    {
        Console.WriteLine($"{year}");
    }
}

int GetInteger(string prompt, int min, int max)
{
    while (true)
    {
        Console.Write(prompt);
        var answer = Console.ReadLine();
        if (int.TryParse(answer, out var result) &&
            result >= min &&
            result <= max)
        {
            Console.WriteLine("OK");
            return result;
        }

        Console.WriteLine($"Year must be between {min} and {max}.");
    }
}

/* -------------------- */
//Assignment 7


﻿XYColumns(5, 10);

void XYColumns(int x, int y)
{
    for (var row = 0; row < x; row++)
    {
        for (var column = 0; column < y; column++)
        {
            Console.Write($"{(x * column) + row:D2} ");
        }
        Console.Write(Environment.NewLine);
    }
}

/* -------------------- */
// Assignment 8

﻿CalculateWidthAndHeight(3, 200, 120);
CalculateWidthAndHeight(9, 1000, 1000);

void CalculateWidthAndHeight(double area, double x, double y)
{
    var room = x * y;

    var roomSqrt = Math.Sqrt(room);
    var areaSqrt = Math.Sqrt(area);

    var ratio = areaSqrt / roomSqrt;

    Console.WriteLine($"Width  = {x * ratio:F2} meters.");
    Console.WriteLine($"Height = {y * ratio:F2} meters.");
}

// Here is an alternative solution sent in by a previous yrgo student!
void CalculateWidthAndHeight2(double area, double x, double y)
{
    var room = x * y;
    var ratio = Math.Sqrt(area / room);

    var width = x * ratio;
    var height = y * ratio;

    Console.WriteLine($"Width  = {width:F2} meters.");
    Console.WriteLine($"Height = {height:F2} meters.");
}

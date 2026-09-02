# 03 - Strings

Today we'll learn about strings in C# and how to use **`continue`** to write better code.

## Using continue

The **`break`** keyword used to break out of loops has a twin called **`continue`** that does the opposite, it moves back to the loop and _continues_. The **`continue`** keyword is not C# specific and is available in most other C based languages as well, but is often neglected in favor of nesting **`if`** statements.

Let's consider an application that repeatedly ask the user for their age and exit when they confirm that they are 18 or older.

<details>
<summary>Version 1 - using nested if statements</summary>

```csharp
while (true)
{
   Console.WriteLine("How old are you?");

   var answer = Console.ReadLine();

   if ( ! int.TryParse(answer, out var age))
   {
      Console.WriteLine("That's not an age I understand");
   }
   else
   {
      if (age < 18)
      {
         Console.WriteLine("You have to be 18+, try again");
      }
      else
      {
         Console.WriteLine("Welcome!");
         break;  // exit the loop
      }
   }

   // ask again
}
```

</details>

<details>
<summary>Version 2 - using continue</summary>

```csharp
while (true)
{
   Console.WriteLine("How old are you?");

   var answer = Console.ReadLine();

   if (!int.TryParse(answer, out var age))
   {
      Console.WriteLine("That's not an age I understand");
      continue;  // ask again
   }

   if (age < 18)
   {
      Console.WriteLine("You have to be 18+, try again");
      continue;  // ask again
   }

   Console.WriteLine("Welcome!");
   break;  // exit the loop
}
```

</details>

Version 2 has a more natural flow and is easier to read as it moves back to the loop immediately at the point of error while avoiding using nested branch logic. Nested if statements are not invariably evil, it's all about context and readability. Using many nested if statements is however often a sign of poor design that can be improved in one way or another.

## Strings

C# strings have more in common with JavaScript than PHP in that they are unicode and _objects_ with methods and properties, rather than just a stream of raw bytes.

### Convert to lowercase or uppercase

Just like in PHP there are a lot of ways to manipulate strings in C#. In PHP, you send a string variable to a function like `strtolower($name)`, in C# the equivalent would be to run the method `name.ToLower()` on the string itself to return a modified copy.

```csharp
var movie = "Blade Runner";

movie = movie.ToLower();  // movie = "blade runner"
movie = movie.ToUpper()   // movie = "BLADE RUNNER"
```

### Replace parts of a string

```csharp
var text = "More human than human is our motto";

Console.WriteLine(quote.Replace("human", "toaster"));   // More toaster than toaster is our motto
```

### Return a part of a string

Trying to access a character outside the boundaries of a string crashes the application, as this is not an error that can be caught by the compiler. We will look into how to deal with runtime errors in the future.

```csharp
var quote = "If only you could see what I've seen with your eyes";

Console.WriteLine(quote.Substring(0, 7));     // "If only"
Console.WriteLine(quote.Substring(22));       // "what I've seen with your eyes"
```

Modern versions of C# also has a _range_ operator you can use on strings, it's pretty neat but you don't have to remember or use this:

```go
var quote = "If only you could see what I've seen with your eyes";

Console.WriteLine(quote[..7]);      // "If only"
Console.WriteLine(quote[22..]);     // "what I've seen with your eyes"
Console.WriteLine(quote[..^14]);    // "If only you could see what I've seen"
Console.WriteLine(quote[^14..]);    // "with your eyes"
Console.WriteLine(quote[^14..^4]);  // "with your"
```

### Get the length of a string

Note that it is `.Length` and not `.Length()` - This is something called a _property_ in C#, and it returns a value just like a method. We will look into properties in the future as well.

```csharp
var quote = "I watched C-beams glitter in the dark near the Tannhauser gate";
var length = quote.Length;  // 62
```

## Assignments

### Assignment 3-1

Time to work, the CEO has a great idea for a new game. You are not impressed.

- Randomize a number between 1 - 99.
- Let the user guess which number it is.
- If they get it wrong, give them a hint.
- Game ends when they get the number right.

This is how the game should play out:

<pre>
Guess a number: <b>korv?</b>
that is not a number

Guess a number: <b>10</b>
too low

Guess a number: <b>40</b>
too low

Guess a number: <b>50</b>
too high

Guess a number: <b>42</b>
that is correct
</pre>

This is how you pick a random number in C#:

```csharp
var random = new Random();
var number = random.Next(1, 11);   // min is inclusive, max is exclusive

Console.WriteLine($"Random number between 1 and 10: {number}");
```

Try solving this using **`continue`** statements rather than nesting **`if`** statements.

### Assignment 3-2

To your surprise the new game is a hit, but with infinite guesses it's a bit too easy to win.

Update the game so that the user only get to guess three times before it ends with a friendly "Game Over" message.

<pre>
[1/3] Guess a number: <b>korv?</b>
that is not a number

[1/3] Guess a number: <b>10</b>
too low

[2/3] Guess a number: <b>40</b>
too low

[3/3] Guess a number: <b>66</b>
too low

GAME OVER
</pre>

### Assignment 3-3

Despite your newfound success in game development you move on to a new company that have a huge list of names they need normalized. Write a method called `Normalize` that normalize a string by returning the first letter as uppercase and everything else as lowercase.

You are assured that a string can never be empty.

```csharp
var firstname = Normalize("GUYBRUSH");
var lastname  = Normalize("threepwood");

Console.WriteLine($"{firstname} {lastname}");
```

<pre>Guybrush Threepwood</pre>

### Assignment 3-4

One of the old IBM AS/400 servers have broken down at the local bank, its one task was to summarize all digits in a string. You're paid handsomely to come up with a replacement.

Call your new method `SumAllDigits`, it should take a string containing all digits and simply return the sum of them as an integer.

```csharp
var input = "4719";
var value = SumAllDigits(input);

Console.WriteLine($"Sum of {input} = {value}");
```

<pre>Sum of 4719 = 21</pre>

<details>
<summary>Hint</summary>

This is actually a lot easier than it might look at a glance. First you need to iterate over the string and extract one letter at a time, then you simply use `int.TryParse()` from last week to convert that letter to an integer.

</details>

## Assignment 3-5

Ask the user for their name, then write each letter in the name one at a time, as many times as the name is long. You start to question the sanity of your employer.

<pre>
What is your name? <b>Guybrush</b>

Guybrush
GGGGGGGG
UUUUUUUU
YYYYYYYY
BBBBBBBB
RRRRRRRR
UUUUUUUU
SSSSSSSS
HHHHHHHH
</pre>

<details>
<summary>Hint</summary>

You can use two nested **`for`** loops here.

</details>

### Assignment 3-6

Time to help out the security team.

Create a method called `IsValidPassword` that takes a string as argument and return **`true`** if the password is good enough to be a password, otherwise **`false`**.

Here are the business requirements:

- A valid password must be at least 8 characters long
- A valid password must contain at least 2 digits
- A valid password must not be only digits

```csharp
Console.WriteLine(IsValidPassword("short"));
Console.WriteLine(IsValidPassword("password"));
Console.WriteLine(IsValidPassword("12345678"));
Console.WriteLine(IsValidPassword("xxxxxxx0"));
Console.WriteLine(IsValidPassword("p4ssw0rd"));
```

<pre>
False
False
False
False
True</pre>

No matter how you go about to solve this you'll undoubtedly have to check if a piece of a string is a digit or not. While you can definitely use `int.TryParse` there is also a method called `char.IsDigit` that work like this:

```csharp
var text = "test123";

for (var i = 0; i < text.Length; i++)
{
    var result = char.IsDigit(text, i);
    Console.WriteLine(result);
}
```

<pre>
False
False
False
False
True
True
True
</pre>

<details>
<summary>Hint 1</summary>
This does get complicated if you try to do everything at once. Think of each business requirement as their own method. Try avoiding nested statements!
</details>

<details>
<summary>Hint 2 (spoiler)</summary>
By splitting this into several individual methods it suddenly become a lot more manageable and the code is easier to read. Remember, good code is often straight forward and boring. Using the template below all you have to do is implement the three rules that make up the password validation.
<br>
 
<br>

```csharp
// implement these
bool HasMinimumLength(string input, int length) { return false; }
bool HasNonDigits(string input) { return false; }
bool HasAtLeastTwoDigits(string input) { return false; }

bool IsValidPassword(string input)
{
   if (!HasMinimumLength(input, 8))
         return false;

   if (!HasNonDigits(input))
         return false;

   if (!HasAtLeastTwoDigits(input))
         return false;

   return true;
}
```

</details>

## Assignment 3-7 (Extra)

It's Christmas! Well, eh. Let the user input a number and render a Christmas tree of that size (= number of lines). Don't forget to add "[ ]" to the bottom center of the tree so it looks pretty.

You can create a new string with repeated "\*" like this:

```csharp
// note the single quotes in '*'
var repeated = new string('*', 5);   // "*****",
```

<pre>
Please input the size of your Christmas tree: <b>8</b>

         *
        ***
       *****
      *******
     *********
    ***********
   *************
  ***************
        [ ]
</pre>

For extra holiday bonus points you can set color to the tree using `Console.ForegroundColor = ConsoleColor.Green` and `ConsoleColor.DarkYellow` for the trunk, wow!

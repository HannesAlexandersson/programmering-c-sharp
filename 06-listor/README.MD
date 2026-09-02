# List&lt;T>

`List<T>` (_list of T_) is a simple generic implementation of a collection of items. In contrast to other collection types in C#, the `List<T>` class has no fancy constraints and is the most commonly used way to store data that can shrink or grow in size.

A `List<T>` is type safe using generics, the compiler will make sure it's not possible to add anything other than the defined type.

> To iterate, modify and filter data, C# has a built in SQL like query language called _LINQ_ that you might have heard about. LINQ is a very powerful feature of C#, but to not complicate things we will learn it another day.

This is how you create an empty list of strings and add to it:

```csharp
var movies = new List<string>();

movies.Add("Blade Runner");
movies.Add("Robocop");
movies.Add("Aliens");
// movies.Add(2001);   this wouldn't compile, 2001 is not a string
```

It's also possible to create the list with initial values, this would do the same thing:

```csharp
var movies = new List<string>()
{
    "Blade Runner",
    "Robocop",
    "Aliens"
};
```

To count how many items there are in a list we use the `Count` property.

```csharp
// items in list = 3
Console.WriteLine($"items in list = {movies.Count}");
```

To move through a list we can use a `foreach`:

```csharp
foreach (var movie in movies)
{
    Console.WriteLine(movie);
}
```

...or like this, with a `for` loop:

```csharp
for (var i = 0; i < movies.Count; i++)
{
    Console.WriteLine(movies[i]);
}
```

Checking for or deleting a `string` item is equally straight forward:

```csharp
if (movies.Contains("Robocop"))
{
    movies.Remove("Robocop");
}

// items in list = 2
Console.WriteLine($"items in list = {movies.Count}");
```

## Assignments

_In these assignments we'll try something new! You will have to use unfamiliar code written by someone else and add your code to an existing code base. You don't need to create a new project for each assignment as this will be one big application._

## Assignment 6-1a

The Initech corporation need to keep track of all their partners in a simple database application. Managers should be able to view, add and delete company names. Unfortunately, the original developer quit the project and you're left you to save the day, as usual.

Here's the code you have to work with:

`DatabaseApplication.cs`

```csharp
class DatabaseApplication
{
    public List<string> Database { get; } = new List<string>();
    public List<string> Commands { get; } = new List<string>
    {
        "add",
        "help",
        "list",
        "quit"
    };

    public void Run()
    {
        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("*** Welcome to Initech Data Systems 1.0 ***");
        Console.WriteLine();
        Console.ResetColor();

        string command;

        do
        {
            command = GetCommand();

            if (command == "add")
            {
                Console.WriteLine("add...");
            }
            else if (command == "help")
            {
                Console.WriteLine("help...");
            }
            else if (command == "list")
            {
                Console.WriteLine("list...");
            }

        } while (command != "quit");
    }

    public string GetCommand()
    {
        while (true)
        {
            Console.Write("Please input a command, or \"help\": ");

            var input = Console.ReadLine()!;

            if (Commands.Contains(input))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OK");
                Console.WriteLine();
                Console.ResetColor();

                return input;
            }

            Console.WriteLine("?");
            Console.WriteLine();
        }
    }
}
```

And this is how you run it from your `Program.cs`

```csharp
var application = new DatabaseApplication();
application.Run();
```

Copy the code into a new project and make sure it compiles and run. All it can do for you is take commands from the user and quit, but at least you don't have to spend time writing that.

## Assignment 6-1b

Typing **help** should list all available commands in the application, but it should not include help itself.

<pre>
Please input a command, or "help": <b>help</b>
OK

-- Available commands --
add
list
quit
</pre>

<details>
<summary>Hint</summary>

For this simply use a `foreach` to go through all the available commands and write each one to the screen, and use an `if` statement to skip "help".

Also, it's probably a good idea to create a new method for each new command, or else the `Run()` method will grow very big.

</details>

## Assignment 6-1c

Using the **add** command should ask the user for a new company name and add it to the database. If the company name is an empty string, the user obviously changed their mind and you should not add it to the database.

Notice that at this point, the database is obviously still only kept in memory and therefore will be empty every time the application restarts.

<pre>
Please input a command, or "help": <b>add</b>
OK

Please input company name to add: <b>Yamaha</b>
Company added to database!

Please input a command, or "help": <b>add</b>
OK

Please input company name to add: <b>Tesla</b>
Company added to database!
</pre>

## Assignment 6-1d

Next, let's implement the "list" command to show all companies in the database.

<pre>
Please input a command, or "help": <b>list</b>
OK

Yamaha
Tesla
--
Companies in database: 2
</pre>

## Assignment 6-1e

On the wish list is a new **delete** command, it should delete a company from the database if it exists, or output an error if it doesn't.

<pre>
Please input a command, or "help": <b>delete</b>
OK

Please input company name to delete: <b>Yamaha</b>
Company deleted from database!

Please input a command, or "help": <b>delete</b>
OK

Please input company name to delete: <b>korv?</b>
Error: Company not found in database!
</pre>

## Assignment 6-1f

Using a `List<T>` sure is very fast and efficient, but management is starting to get unhappy that the database is cleared every time the application is restarted.

To do this, you need to create a new `Load()` and `Save()` method that will load and save the contents of the list in the application.

Create a constructor to `Load()` the database when the application is started, and call `Save()` every time you add or delete to it.

Here is some code that showcase how to read and write a list to a text file:

```csharp
var list = new List<string> { "KORG", "Roland", "Yamaha", "Kawai" };

// where to write the list, if you're on Windows you need to
// change this or create a c:\tmp folder
var filename = "/tmp/database.txt";

// ...and save it to the file "/tmp/database.txt",
File.WriteAllLines(filename, list);
```

Then, to later read the file back and into a `List<string>` we can do this:

```csharp
var filename = "/tmp/database.txt";
var list = new List<string>();

// if the file exists, read it and create a list from it
if (File.Exists(filename))
{
    list = File.ReadAllLines(filename).ToList();
}

foreach (var company in list)
{
    Console.WriteLine(company);  // KORG, Roland, etc
}
```

## Assignment 6-1g

Management is very happy with your progress, but the testers have found a bug: it's possible to add the same company twice! This is not good, update your code so that adding the name of an existing company result in an error message instead.

Oh, and make sure it works with both upper and lowercase.

<pre>
Please input a command, or "help": <b>add</b>
OK

Please input company name: <b>yamaha</b>
OK

Please input company name: <b>YAMAHA</b>
Error: company already exist in database!
</pre>

This is the somewhat verbose but recommended way to do case insensitive comparison of two strings in C#:

```csharp
if (String.Equals("abc", "ABC", StringComparison.OrdinalIgnoreCase))
{
    // true
}
```

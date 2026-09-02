# 01 - Börja jobba med C#

i den här övningen kan vi lära oss lite basala syntax grejer och få lite mer vana vid att jobba med Visual Studio.  Så här kommer varje del att se ut, först har jag lite genomgångar och exempel och sedan nedanför så finns det övningar. Facit finns i facit foldern!

## C# and .NET

To develop and run applications written in the C# language we need a runtime. The parts that make up this runtime is called .NET and has a long history of being a closed Windows only framework, however that all changed a few years ago and both C# and .NET are now open source projects that run on every major platform.

## Basics of C#

C# is a "C style" language, just like PHP and JavaScript, so much of its core syntax should be immediately familiar. The language is based around an object oriented design, very similar to Java but with a lot of inspiration from functional languages added over the years, but we don't really need to care about any of that today.

### Hello World

This is Hello World in PHP:

```php
// Hello World
print "Hello, world\n";
```

And this is the same program in C#:

```csharp
// Hello World, version 1
using System;

class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, world");
    }
}
```

That is a lot of code, but with the most recent release of C# it's possible to omit almost all of it and just write:

```csharp
// Hello world, version 2
Console.WriteLine("Hello, world");
```

We are going to use the shorter syntax. However even when you write the shorter syntax it's important to understand that both versions are equivalent; all that weird _"static void Main blah blah"_ code is just magically created for us when the program is compiled.

### Comments

C# supports both `/* */` and `//` to comment code. There is a third comment style called "XML Documentation Comments" which can be used to extract documentation from source code as XML, but - again - this is also something we don't need to care about today.

### Variables and types

When you declare a variable in C# you give it a type*, but unlike dynamic languages you can't magically change a variable to a new unrelated type later on*.

```csharp
int answer = 42;
string name = "Guybrush";
bool pirate = true;
double value = 1.337;

// this doesn't work, as "name" is a string and "answer" is an int
name = answer;
```

C# also supports what's called _type inference_ using the keyword `var`. When using type inference the compiler will try to guess the type of the variable based on its assigned value.

```csharp
var answer = 42;        // same as int answer = 42
var name = "Guybrush";  // same as string name = "Guybrush"
var pirate = true;      // same as bool pirate = true
var value = 1.337       // same as double value = 1.337
```

Since the compiler needs an assigned value to figure out the correct type it's not legal syntax to use `var` without one.

```csharp
// this would be ok, "name" is declared as a string but without a value
string name;

// but this would be a syntax error, the compiler can't figure out what type "name" is
var name;
```

\*_Note: Actually, you can do some werid things in C# to make it behave more dynamic, but that is black magic and wrong._

## Control structures

Thankfully, C# share many of the same controls structures that we know from JavaScript and PHP.

| Keyword            |
| ------------------ |
| **`break`**        |
| **`continue`**     |
| **`do ... while`** |
| **`for`**          |
| **`foreach`**      |
| **`if`**           |
| **`switch`**       |
| **`while`**        |

However, there are some differences you might run into right away.

## A boolean expression must be true or false

The evaluation of a conditional expression must return either `true` or `false` - there is no such thing as 0 or an empty string representing the value `false`.

```csharp
var data = 0;

// this is a compiler error in C#, but data == 0 would work
if (!data)
{
    Console.WriteLine("data is empty");
}
```

## Variables must be set and have scoping rules

A variable can not be used before it has a value, and we can not access a variable outside of its scope.

```csharp
string name;

// compiler error, name has no value
Console.WriteLine(name);
```

This code would print "10" in PHP and JavaScript, but doesn't compile in C#:

```csharp
for (var i = 0; i < 10; i++)
{
    ...
}

// compiler error, "i" isn't accessible outside of the scope of the for-loop where it was declared.
Console.WriteLine(i);
```

## Using the Console

### Writing to the screen

We have seen how to write a string to the screen using `Console.WriteLine`, but what if we want to include the value of a variable? There are several ways we can accomplish this, but the recommended way is usually to use _string interpolation_:

```csharp
var name = "Guybrush";

// Notice the $
Console.WriteLine($"My name is {name}, I'm a mighty pirate");

// ...but, we can also do it like this:
Console.WriteLine("My name is" + name + ", I'm a mighty pirate");
Console.WriteLine("My name is {0}, I'm a mighty pirate", name);
```

In addition to `Console.WriteLine` there's also a `Console.Write` method that doesn't add a trailing line break to the output.

### Reading input

We can also read input from the screen using `Console.ReadLine()`.
This will stop the execution of the program, waiting for a full line to be written to the console.
A line always ends with a new line character. And we create a new line charact by pressing enter :)

```csharp
Console.Write("Please type your name: ");

var name = Console.ReadLine();

Console.WriteLine($"Hello {name}");
```

## Assignments

### Using solutions in Rider

In Rider we will work in what's known as _Solutions_. A Solution is just a container for one or more _Projects_ that may or may not have dependencies on each other. Every week we will create a new solution that contain all assignments as projects.

How to create a new solution:

- Start Rider
- Click on `New Solution`
- Select the `Console Application` template
- Set `Project Name` to "Assignment1" and `Solution Name` to "Week1"
- Click `Create`

<img src="solution-explorer.png">

### Assignment 1-1

Your first assignment as a new C# consultant is to develop a very basic ticket system for a very important customer:

_We have three ticket categories in our system:_

| Category | Price |
| -------- | ----: |
| A        |   $33 |
| B        |   $40 |
| C        |   $60 |

_We need you to write an application that asks the user which ticket they want to purchase. If they fail to provide a correct answer, ask again. A customer can only buy one ticket._

Your application should work like this:

<hr>
<pre>
Welcome to Amazing Ticket Systems 1.0<br>
Which ticket would you like?
Type A, B or C: <b>korv?</b>
I'm sorry, that's not a valid ticket.<br>
Which ticket would you like? 
Type A, B or C: <b>B</b>
You have selected B, your total is $40</pre>

<details>
<summary>Hint</summary>

You can use a `while` loop to keep asking until the user give a correct answer.

</details>

### Assignment 1-2

> To add a new "Assignment2" project to your solution, right click on the solution name ("Week1") and select `Add` → `New Project...`. Then to have Rider build and run this project, select it from the dropdown next to the run button.

The customer is very satisfied and comes back with a new business requirement:

_If we are selling a category C ticket, I want the system to ask if they want to purchase our special VIP package for an additional $20. As before, ask again if they fail to answer yes or no._

Your application should work like this:

<hr>
<pre>
Welcome to Amazing Ticket Systems 2.0<br>
Which ticket would you like?
Type A, B or C: <b>C</b><br>
Would you like our special VIP package with that? +$20
Type yes or no: <b>yes</b><br>
You have selected C+VIP, your total is $80</pre>
</pre>

### Assignment 1-3

They're back with one final update:

_We want the user to identify themselves with their email. If they're using an email from a partner they get a 20% discount on the total price. Known partners are emails ending with "@yrgo.se" or "@w3c.org"._

Your application should work like this:

<hr>
<pre>
Welcome to Amazing Ticket Systems 3.0<br>
Please type your email: <b>vincent@yrgo.se</b>
A 20% discount will be applied at checkout!<br>
Which ticket would you like? ...etc 
</pre>

To check if a string ends with something:

```csharp
var name = "Hello world";

if (name.EndsWith("world"))
{
    // ... do something
}
```

To use string interpolation with decimal formatting:

```csharp
var pi = 3.14159;

Console.WriteLine($"pi = {pi:F2}");  // pi = 3.14
```

### Assignment 1-4

For your new assignment you're hired by a group of people in expensive clothing and sunglasses to write a secure login system.

_The application should be initialized with a known username and password, and then ask the user to identify themselves. If the user fail to do so three times the application should exit._

This is the only username/password combination the system accepts:

```csharp
username = "falken"
password = "joshua"
```

Your application should work like this:

<hr>

<pre>
Welcome to NORAD Online Systems

Input username: <b>guybrush</b>
Input password: <b>korv?</b>
INCORRECT<br>
Input username: <b>guybrush</b>
Input password: <b>kebab!</b>
INCORRECT<br>
Input username: <b>guybrush</b>
Input password: <b>ples</b>
INCORRECT<br>
Application shutdown, bye!</pre>

If the user input the correct username and password you should write a nice login message, like _Greetings professor Falken, would you like to play a game?_

### Assignment 1-5

With your success in the ticket market you're quickly headhunted into retail.

_We are running a promotion where you get the cheapest item for free. Given the value of three items (A, B and C), output what the customer should pay in total. Our staff is really bad at math._

Here's an example:

```csharp
var A = 50;
var B = 45;
var C = 90;

// TODO: write your solution here
```

Given the values above, your application should print this:

<hr>
<pre>
Your total is $140:-
</pre>

<details>
<summary>Hint</summary>

Figure out a way to find the cheapest item, then subtract it from the total value. You can solve this by using `if` statements, or - slightly more advanced - by using the common math function `min`, which is available in .NET as `Math.Min()`.

</details>

### Assignment 1-6 (Extra)

One of your key assets as a code mercenary is understanding other people's ~~mess~~ work.

The code below does produce the correct output, but it is really hard to understand how it works. Rewrite it so that it's using a simple `for` loop instead.

```csharp
var start = 3;
var stop = 1278;

// TODO: What is this I don't even
do
{
    Console.WriteLine(start++);

    if ((start = start + start) > stop)
        break;
}
while(true);
```

## Resources

<a href="https://docs.microsoft.com/en-us/shows/CSharp-101/?WT.mc_id=Educationalcsharp-c9-scottha">C# 101 Video Series</a><br>
Good but slow (maybe a bit too slow for some of you) introduction to C# from Microsoft.

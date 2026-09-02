# 02 - Methods

I den här delen arbetar vi med metoder och kommer att convertera strängar till nummer och mycket mera!

## Methods in C#

Methods in C# serve the same purpose as functions in PHP and JavaScript.

By convention, and in contrast to many other popular languages, methods in C# are written with each individual word of the name capitalized in a style called _PascalCase_.

```csharp
ThisIsFine()          // C#
thisIsWrong()         // Java, PHP, JavaScript
this_is_also_wrong()  // Ruby, Python
```

## Writing a new method

In its most basic form, a method in C# that take a string as an argument and return nothing looks like this:

```csharp
void SayHelloTo(string name)
{
    Console.WriteLine($"Hello, {name}");
}

SayHelloTo("Guybrush Threepwood");

//
// if it makes the code more readable, we can specify the name of the argument too:
// SayHelloTo(name: "Guybrush Threepwood");
//
```

<pre>Hello, Guybrush Threepwood</pre>

### Returning values

We can update the method to return the greeting, instead of printing it to the screen, by using the familiar **`return`** keyword and changing the return type from **`void`** to **`string`**.

```csharp
string SayHelloTo(string name)
{
    return $"Hello, {name}";
}

var greeting = SayHelloTo("Guybrush Threepwood");

Console.WriteLine(greeting);
```

<pre>Hello, Guybrush Threepwood</pre>

It's a compiler error to return anything but the data type specified as the return value, so this doesn't work:

```csharp
// error - can't return a string with int as return type
int SayHelloTo(string x)
{
    return $"Hello, {name}";
}
```

Furthermore, the program won't compile if it's possible for a method to not return the specified type\*.

```csharp
// error - doesn't return a bool if age is < 18
bool IsAdult(int age)
{
    if (age >= 18)
        return true;
}
```

\*_Note: It is possible to raise an error (Exception) in a method and leave it without returning a value, but we will save that for a future lesson._

### Arrow syntax

A method in C# that consists of a single line returning a value can be written using _arrow syntax_ with the **`return`** statement omitted. As such, the `SayHelloTo` method can be written like this:

```csharp
string SayHelloTo(string name) => $"Hello {name}";
```

Writing methods like this is just for swag points and to reduce typing, the method is exactly the same as before.

## Converting strings to numbers

There is more than one way to convert a string to an integer, but the most common and usually best way is to use `int.TryParse` which returns **`false`** if the value could not be converted.

This is the first and probably last time you will encounter an **`out`** parameter, they exist to allow for a C# method to return more than one value and are rarely used.

```csharp
var input = "9";  // string value to convert

if (int.TryParse(input, out var number)) {
    Console.WriteLine($"The square root of {number} is {Math.Sqrt(number)}");
} else {
    Console.WriteLine("That's not an int.");
}
```

<pre>The square root of 9 is 3</pre>

> You might notice the odd syntax where "number" is seemingly declared _inside_ TryParse along with the "out" keyword, but its scope is actually _outside_ the if statement. Nothing else in C# works like this, it's simply a compiler trick the language designers added after a few years to save the developers from having to declare the out variable on a line of its own. It is weird!

## Assignments

### Assignment 2-1

Your rising career in software development is cut short after you forget to buy fika to an important meeting. Now demoted to accounting, you need to write a method that take three **`double`** values and return the average.

```csharp
var average = GetAverage(5, 10, 7.4);

Console.WriteLine($"Average: {average:F2}");
```

<pre>Average: 7,47</pre>

### Assignment 2-2

You're promised your job back if you can supply your team with method named `GetInteger`, that return an integer by repeatedly asking the user until they give a valid answer.

Additionally, the method should take a **`string`** as argument which should be used as the text presented to the user.

It should work like this:

```csharp
var number = GetInteger("Please type a number: ");

Console.WriteLine($"Your number is {number}.");
```

<pre>
Please type a number: <b>no</b>
Please type a number: <b>a number</b>
Please type a number: <b>42</b>
Your number is 42.
</pre>

<details>
<summary>Hint</summary>

The easiest way to solve this is probably to ask the user in a `while(true) { ... }`, and when a valid number is given use a `return` to exit the loop and return the value from the method.

</details>

### Assignment 2-3

You need to update your `GetInteger` method to take two additional arguments, `min` and `max` integers. Now the answer must not only be an integer, it has to be within this range.

It should work like this:

```csharp
var number = GetInteger("Please type a number between 1-2000: ", 1, 2000);

Console.WriteLine($"Your number is {number}.");
```

<pre>
Please type a number between 1-2000: <b>korv?</b>
Please type a number between 1-2000: <b>-19</b>
Please type a number between 1-2000: <b>1337</b>
Your number is 1337.
</pre>

### Assignment 2-4

You got your job back, your new assignment is to write a totally believable math training application thing.

_Our staff is still really bad at math. Have them input two integer values and ask them what the sum is. Let them know if they get it right._

It should work like this:

<pre>
Please input the value for X: <b>14</b>
Please input the value for Y: <b>16</b>
&nbsp;
What is the sum of 14 + 16? <b>30</b>
&nbsp;
30 is correct!
</pre>

### Assignment 2-5

_Hello, it's your friend from last week!_

_We suddenly started to sell huge volumes and the old "buy three, get cheapest free!" thing doesn't work for us anymore. Instead, the customer should get every 10th item for free._

Write a method called `CalculatePrice` that take the number of units and their price as parameters (two integers). The method should then calculate and return the total cost. Remember, every 10th unit is free.

```csharp
Console.WriteLine($"Buying 8 units at $10:- costs ${CalculatePrice(8, 10)}");
Console.WriteLine($"Buying 16 units at $10:- costs ${CalculatePrice(16, 10)}");
Console.WriteLine($"Buying 28 units at $35:- costs ${CalculatePrice(28, 35)}");
```

<hr>
<pre>
Buying 8 units at $10 costs $80
Buying 16 units at $10 costs $150
Buying 28 units at $35 costs $910
</pre>

<details>
<summary>Hint</summary>

You can use math or brute force; simply sum everything in a loop and keep a counter that skip some of the items. It's not very elegant, but it works!

</details>

### Assignment 2-6

Back at the office you pick up a new <a href="https://en.wikipedia.org/wiki/Jira_(software)">Jira ticket</a> with a strange business requirement:

_Don't question why, but our Business Analyst need you to write an application that ask for two years, then write out all years between them and mark every leap year with a star._

- _The years must be between 1 and 9999_
- _The second year must be after the first year_

You can check if a year is a leap year using this code:

```csharp
   var year = 1984;

   if (DateTime.IsLeapYear(year))
   {
      // yes, 1984 was a leap year
   }
```

This is how your application should work:

<pre>
 -- Amazing Leap Year Calculator --
 
 First year: <b>-1</b>
 Year must be between 1 and 9999.
 
 First year: <b>1982</b>
 OK
 
 Second year: <b>1337</b>
 Year must be between 1982 and 9999.
 
 Second year: <b>1988</b>
 OK
 
 1982
 1983 
 1984 *
 1985
 1986
 1987
 1988 *</pre>

_Note - You can probably recycle much of your old GetInteger method to solve this assignment a little faster._

### Assignment 2-7 (Extra)

It's time to do some creative looping, create the method `XYColumns` that can write indexed column data. How incredibly exciting!

```csharp
void XYColumns(int x, int y)
{
    // your code here
}
```

Now given this input:

```csharp
XYColumns(5, 10)
```

Your method should output this:

<pre>
00 05 10 15 20 25 30 35 40 45
01 06 11 16 21 26 31 36 41 46
02 07 12 17 22 27 32 37 42 47
03 08 13 18 23 28 33 38 43 48
04 09 14 19 24 29 34 39 44 49</pre>

You can zero pad in C# using string interpolation and the "D" modifier, `$"{5:D2}"` will return 05

### Assignment 2-8 (Very Extra)

Some time ago I got this problem to solve, it's really not that math heavy but does require some thinking. Let's see if you can figure out a solution.

_We have received floor plans for our new office building, and the size of all rooms are defined in m<sup>2</sup> - but we need to know the actual length of the walls in each room._

Here's a typical small room:

<img src="room.png">

- The area of the room is **3m<sup>2</sup>**
- The X (width) is **200** pixels
- The Y (height) is **120** pixels

</p>

Create a method that output the length of the walls (width and height of the rectangle) in meters, with two decimals:

```csharp
void CalculateWidthAndHeight(double area, double x, double y)
{
    // your code here
}
```

Now given this input:

```csharp
CalculateWidthAndHeight(3, 200, 120);
```

```csharp
CalculateWidthAndHeight(9, 1000, 1000);
```

Your method should output this:

<pre>
Width  = 2,24 meters
Height = 1,34 meters
</pre>

<pre>
Width  = 3,00 meters
Height = 3,00 meters
</pre>

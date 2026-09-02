# 07 - Arrays

Arrays in C# have a fixed size, they can not shrink or grow and trying to write outside the size of an array will crash the application if not handled correctly.

Like in most languages, arrays in C# are _zero indexed_, meaning the first element start at 0.

```csharp
// create an int array with a size of 10
var data = new int[10];

// or, same thing but using the array[] type directly
// int[] data = new int[10];

// set index 4 to value 7
data[4] = 7;

// 0,0,0,0,7,0,0,0,0,0,
for (var i = 0; i < data.Length; i++)
{
    Console.Write(data[i] + ",");
}

// same as above
foreach (var item in data)
{
    Console.Write(item + ",");
}

// this will crash the application at run time, size is 0 to 9
Console.WriteLine(data[10]);
```

It's also possible to initialize an array at creation. The compiler is then smart enough to infer the type, so we don't have to write `new string[]` here if we don't want to.

```csharp
var names = new []
{
    "Egon Spengler",
    "Peter Venkman",
    "Ray Stantz",
    "Winston Zeddemore",
};

// 4
Console.WriteLine(names.Length);
```

You can also use a collection expression, but this style only works when the type is know. So in this case we have to specify the type and not use `var`.

```csharp
string[] names =
[
    "Egon Spengler",
    "Peter Venkman",
    "Ray Stantz",
    "Winston Zeddemore"
];
```

## Array dimensions

_Except for the extra assignment today we're not going to make use of multidimensional arrays, so feel free to forget all about this section._

Somewhat curious, an array in C# can have several dimensions. This can be useful when working with raw 2D or 3D data.

```csharp
var data = new int[7, 4];  // a new empty 2D 7x4 array

// or, same thing but using the array[,] type directly
// int[,] data = new int[7, 4];

var width  = data.GetLength(0);  // 7
var height = data.GetLength(1);  // 4

 // change a single value in the array at 4, 2
data[4, 2] = 5;

for (var y = 0; y < height; y++)
{
    for (var x = 0; x < width; x++)
    {
        Console.Write(data[x, y]);
    }

    Console.WriteLine();
}
```

<pre>
0000000
0000000
0000500
0000000
</pre>

> There is actually a third array type, _jagged array_ that consists of arrays of different sizes! They are a rare beast and we're not going to cover them, but you can <a href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/jagged-arrays">read about them here</a> if you want. You probably don't. I wouldn't.

# Assignments

Now let's do some array things!

## Assignment 7-1

Write the method `ThresholdSum` that summarize the values in an `int[]` array that are above a given threshold.

```csharp
var input = new [] { 6, 1, 4, 5, 2, 8 };
var output = ThresholdSum(input, 4);  // 6 + 5 + 8

Console.WriteLine(output); // 19
```

## Assignment 7-2

Write the method `GetLongestString` that take a `string[]` argument and return the longest string<a href="https://www.youtube.com/watch?v=LQsMp4Oo6xM">.</a>

```csharp
var names = new []
{
    "Egon Spengler",
    "Peter Venkman",
    "Ray Stantz",
    "Winston Zeddemore",
};

var output = GetLongestString(names);

Console.WriteLine(output);  // Winston Zeddemore
```

## Assignment 7-3

> This is, allegedly, the first and easiest problem Google will have you solve before getting an interview with the company. It's not very hard, but there are several ways to solve it.

Write the method `FindDuplicateNumber`. When given an array containing an unknown number of positive integers, return the number that has a duplicate. Assume that there can never be more than one duplicate number in the array. If no duplicated number is found, return -1.

```csharp
var number = FindDuplicateNumber(new[] { 2, 14, 95, 8, 20, 14, 7, 3 });

Console.WriteLine(number);  // 14
```

## Assignment 7-4

_Hi and welcome to The Map Company! We need you to write some computer thing that help us calculate how much land there is on any given map. Our maps are very simple, "." represents water and "#" represents land. Here's a typical map: <a href="map.txt">map.txt</a>. I hope you find this task inspiring because we'll be back next week with another assignment for you._

Write an application that can read the map data and tell how much land there is ( = counts how many # there are on the provided map _spoiler: 55_).

### How to add a text file as a resource to your project so your application can read it:

<details>
<summary>Rider</summary>
    
* Download the `map.txt` file somewhere on your computer
* Right click on the project name in Rider
* Select "Add" → "Existing Item..." and select the `map.txt` file
* Right click on `map.txt` in your project
* Select "Properties"
* Change "Copy to output directory" from "Do not copy" to "Copy always"
    
</details>

You should now be able to read the file as an array of strings using `File.ReadAllLines("map.txt")`.

## Assignment 7-5 (Extra)

Let's write Tetris! Hmm, we might not have the time for that, so let's just do a tiny part for now: rotating a block in one direction. A Tetris block is a matrix (2D array) of 4x4, 3x3, or 2x2 that can be rotated left or right.

Write a `RotateLeft()` method that takes a matrix of any size as the argument and returns it rotated 90 degrees.

It should work like this:

```csharp
var block = new byte[,] {    // a "byte" is just a small integer type
    { 0, 0, 0 },
    { 1, 1, 1 },
    { 0, 1, 0 },
};

block = RotateLeft(block);
// block is now:
//  0 1 0
//  0 1 1
//  0 1 0

block = RotateLeft(block);
// block is now:
//  0 1 0
//  1 1 1
//  0 0 0
```

<details>
<summary>Hint</summary>
Trying to move the bytes around in the block with crazy bit shifting or whatever will be waaay complicated, instead you can create a new multidimensional array of the same size, copy the bytes into the right places, and return that.
</details>

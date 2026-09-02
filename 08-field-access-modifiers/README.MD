# Access modifiers and fields

Using access modifiers we can control what parts of the class is available to the outside world. By limiting the access to a class we can hide its implementation and make it easier and safer to use. And then we go to space!

## Access Modifiers

Up until today we've mostly used the modifier `public` everywhere, which is "accessable to everyone". On the opposite side is `private`, which is "closed to everyone, except to the type itself". There are <a href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers">several more modifiers in C#</a>, but we don't need to care about them today.

```csharp
public class Guestbook
{
    public bool Write(string message)
    {
        // connect to the database
        Connect();

        // insert the message
        Query("INSERT INTO Guestbook(...");

        // and finally disconnect
        Diconnect();
    }

    private void Connect() { ... }
    private void Query(string sql) { ... }
    private void Diconnect() { ... }
}

var guestbook = new Guestbook();

guestbook.Write("I'm Guybrush Threepwood and I want to be a pirate!");
```

In the code above the `Guestbook` class use a database (well, pretends to), but the _client_ - the user of the class - doesn't need to know that, and can only interact with it through the `Write(message)` method. Trying to access any of the database specific methods from outside the class would be a compiler error since they are `private`.

The `private` modifier is actually the default if no modifier is specified, so the database methods could have (but should not) been written like this:

```csharp
void Connect() { ... }
void Query(string sql) { ... }
void Diconnect() { ... }
```

## Fields

Fields in C# are variables that are `private` and global inside the class. It is common to append an underscore to their name to tell them apart from other variables, but this is not a universal convention.

```csharp
public class Guestbook
{
    // this is a field, any method in the class can access it
    private int _counter = 0;

    public void Write(string message)
    {
        if (_counter == 10)
        {
            Console.WriteLine("Write failure, we have reached the limit.");
            return;
        }

        _counter++;
...
```

In the code above, for some reason the guestbook runs out of space after the tenth message.

## Private properties

In theory, fields can be `public` too, but that is considered very bad practice - if we want to expose data outside the class we should always use a property, and it is possible to have a property with a `public get` and a `private set`.

```csharp
public class Guestbook
{
    // now the counter can be read from anywhere, but only modified inside the class
    public int Counter { get; private set; }
```

## Assignments

_This is one single application, no need to create new projects for each assignment._

Let's go to space! Intergalactic cargo transportation is a very common enterprise business problem.

Today we're going to implement a `Spaceship` that's using a LIFO (Last-In/First-Out) stack to handle its `Cargo`. A LIFO stack is a list where we can only add or remove things from the top - our spaceship can only load and unload in one direction:

<p align="center">
    <img src="express.png">
</p>

Thankfully to cover this business requirement there is a generic LIFO class named `Stack` in .NET already, so we don't need to implement our own:

| Calling this       | Does this                                                    |
| ------------------ | ------------------------------------------------------------ |
| `stack.Push(item)` | Adds an item to the top of the stack                         |
| `stack.Pop()`      | Returns the last inserted item and removes it from the stack |
| `stack.Peek()`     | Returns the last inserted item but does **not** remove it    |
| `stack.Count`      | Returns the number of items in the stack                     |

```csharp
// create a new empty stack with strings
var stack = new Stack<string>();

// add three items to the stack
stack.Push("item 1");
stack.Push("item 2");
stack.Push("item 3");

var item = stack.Pop();   // retrieves "item 3" and removes it from the stack
var count = stack.Count;  // there are now 2 items left in the stack
```

Just like a `List<T>` we can use **`foreach`** to iterate through each item.
Looping over the `Stack<T>` this way leaves the contents of the stack undisturbed.

## Assignment 8-1a

First, we need to copy and paste some code to get started.

### Cargo.cs

Start by creating the `Cargo` class, this is a model used by the items that we can load and unload onto the ship.

A cargo item is very simple right now,

```csharp
public class Cargo
{
    public string Description { get; }

    public Cargo(string description)
    {
        Description = description;
    }
}
```

### Spaceship.cs

Time to start building your spaceship!

Your spaceship has a `Name` and a `_storage` field for its cargo, because the client should not be able modify the storage directly.

```csharp
public class Spaceship
{
    public string Name { get; }

    private Stack<Cargo> _storage = new Stack<Cargo>();

    public Spaceship(string name)
    {
        Name = name;
    }

    //
    // TODO
    //
    // public void AddCargo(Cargo item) {  }
    // public Cargo RemoveCargo() { }
    // public void ListCargo() { }
}
```

## Assignment 8-1b

Now let's implement the first two missing methods in `Spaceship`:

`void AddCargo(Cargo item)`<br>
Add a cargo item to the storage (the stack).

`void ListCargo()`<br>
Prints out (to the console) what's in the storage of the ship, or "&lt;empty>" if there is no cargo.

This should work:

```csharp
var ship = new Spaceship("Planet Express");

ship.AddCargo(new Cargo("Bottles of Slurm"));
ship.AddCargo(new Cargo("Space tomatos"));

Console.WriteLine($"---- {ship.Name} ----");
ship.ListCargo();
```

<pre>
-- Planet Express --
 * Bottles of Slurm
 * Space tomatos
</pre>

## Assignment 8-1c

Finally add the missing `RemoveCargo()` method,

`Cargo RemoveCargo()`<br>
Attempts to remove the last inserted cargo from the storage.

-   The method should return the cargo that is removed.
-   If the storage is empty, the method should instead return **`null`**.

And building on the code above, we should now be able to also remove all cargo from the ship:

```csharp
...
Cargo cargo;

// while RemoveCargo doesn't return null
while ((cargo = ship.RemoveCargo()) != null)
{
    Console.WriteLine($"Removed: {cargo.Description}");
}

Console.WriteLine($"---- {ship.Name} ----");
ship.ListCargo();
```

<pre>
Removed: Space tomatos
Removed: Bottles of Slurm

-- Planet Express --
&lt;empty>
</pre>

## Assignment 8-1d

Currently the cargo has no mass and our spaceship has infinite storage, this is not very realistic.

Update both the `Cargo` and `Spaceship` class and add a `Size` property and set them in their constructors.

```csharp
// This space ship has a total size of 10
var ship = new Spaceship("Planet Express", 10);

// Cargo has a size too
ship.AddCargo(new Cargo("Bottles of Slurm", 3));
ship.AddCargo(new Cargo("Space tomatos", 2));
```

## Assignment 8-1e

Now things get a bit complicated, it should not be possible to add any more cargo if the spaceship doesn't have enough storage space left.

Additionally, also update `AddCargo` to return **`true`** if the cargo was successfully added, and **`false`** if there was not enough room.

```csharp
var ship = new Spaceship("Planet Express", 10);

// load the ship with cargo until AddCargo returns false
while(ship.AddCargo(new Cargo("Bottles of Slurm", 3)))
{
    Console.WriteLine("Cargo added successfully");
}

Console.WriteLine($"---- {ship.Name} ----");
ship.ListCargo();
```

<pre>
Cargo added successfully
Cargo added successfully
Cargo added successfully
-- Planet Express --
 * Bottles of Slurm
 * Bottles of Slurm
 * Bottles of Slurm
</pre>

<details>
<summary>Hint</summary>

Keeping track of the available storage space can be done in different ways:

-   1 create a field that keep track of how much storage space is currently available on the ship
-   2 create a field that keep track of how much storage space has been added to the ship
-   3 calculate how much storage space is left in a new private method and return it

For 1 and 2, you will need to update this field every time cargo is added or removed.

</details>

## Assignment 8-1f

Finally, make it possible for a spaceship to transfer all or some of its cargo onto another ship.

Add this method to the spaceship:

`bool MoveCargoTo(Spaceship spaceship)`<br>
This method should move as much of its cargo as possible to another carrier.

-   The method returns **`true`** if all cargo was successfully transferred, otherwise **`false`**.
-   The LIFO rules still apply, in space we can't unload cargo to get to smaller goods deeper in the stack.

```csharp
var express  = new Spaceship("Planet Express", 10);
var nostromo = new Spaceship("Nostromo", 50);

// add some strange alien eggs to Nostromo
nostromo.AddCargo(new Cargo("Alien eggs #1", 4));
nostromo.AddCargo(new Cargo("Alien eggs #2", 4));
nostromo.AddCargo(new Cargo("Alien eggs #3", 4));

// will move as much as possible from Nostromo to the Planet Express
nostromo.MoveCargoTo(spaceship: express);

Console.WriteLine();
Console.WriteLine($"---- {nostromo.Name} ----");
nostromo.ListCargo();

Console.WriteLine();
Console.WriteLine($"---- {express.Name} ----");
express.ListCargo();
```

<pre>
---- Nostromo ----
 * Alien Eggs #1

---- Planet Express ----
 * Alien eggs #2
 * Alien eggs #3
</pre>

## Assignment 8-2 (Extra)

Write an intergalactic money calculator that returns an integer array with the correct change given a price and cash received from the customer.

Assume the customer always pay with enough money, the price and payment are always integers, and that you have an infinite supply of the following values in your cash register:

<pre>
500
200
100
50
20
10
5
2
1
</pre>

Always give the least amount of change back.

```csharp
var change = GetChangeForCustomer(price: 100, pay: 100);
// change = new [] { }
```

```csharp
var change = GetChangeForCustomer(price: 32, pay: 50);
// change = new [] { 10, 5, 2, 1 }
```

```csharp
var change = GetChangeForCustomer(price: 501, pay: 1000);
// change = new [] { 200, 200, 50, 20, 20, 5, 2, 2 }
```

<details>
<summary>Hint</summary>

It will be unnecessarily complicated to collect the change in an array with a fixed size, it's easier to use a `List<int>` and then return it as a new `int[]` by doing `list.ToArray()`

</details>

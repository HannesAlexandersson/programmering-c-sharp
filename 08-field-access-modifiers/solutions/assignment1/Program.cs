using Assignment1;

var express = new Spaceship("Planet Express", 10);
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

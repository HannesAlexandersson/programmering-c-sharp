using Assignment2;

var luna = new Cat("Luna", false);
var artemis = new Cat("Artemis", true);

Console.WriteLine($"{luna.Name} says: {luna.Speak()}");

artemis.Eat(luna);  // Artemis is a zombie cat, turning Luna into a zombie cat too!

Console.WriteLine($"{luna.Name} says: {luna.Speak()}");

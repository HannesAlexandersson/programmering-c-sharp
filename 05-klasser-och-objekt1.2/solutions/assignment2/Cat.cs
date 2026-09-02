namespace Assignment2
{
    public class Cat
    {
        public string Name { get; }
        public bool Zombie { get; set; }

        public Cat(string name, bool zombie)
        {
            Name = name;
            Zombie = zombie;
        }

        public string Speak()
        {
            return Zombie ? "Braaaaains!" : "Meow!";
        }

        public void Eat(Cat cat)
        {
            if (!Zombie)
            {
                Console.WriteLine($"What?! I will not eat {cat.Name}!");
                return;
            }

            if (cat.Zombie)
            {
                return;
            }

            cat.Zombie = true;
            Console.WriteLine("Nom nom nom");
        }
    }
}

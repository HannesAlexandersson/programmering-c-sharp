namespace Assignment3
{
    public class Robot
    {
        public string Name { get; }
        public int Health { get; set; }

        public Robot(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void Attack(Robot target)
        {
            var damage = Die.Roll();
            target.Health -= damage;

            Console.WriteLine($"{Name} attacks {target.Name} with {damage} damage!");
        }
    }
}

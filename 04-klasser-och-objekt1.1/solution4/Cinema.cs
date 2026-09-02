namespace Assignment4
{
    public class Cinema
    {
        public Movie Movie { get; set; }

        public void MovieInformation()
        {
            Console.WriteLine($"We are currently showing: {Movie.Name} ({Movie.AgeRating} years or older, {Movie.Price}:-)");
        }

        public void ShowMovieTo(Person person)
        {
            if (person.Age < Movie.AgeRating)
            {
                Console.WriteLine($"I'm sorry {person.Name}, you are not old enough.");
                return;
            }

            if(person.Money < Movie.Price)
            {
                Console.WriteLine($"I'm sorry {person.Name}, you don't have enough money.");
                return;
            }

            person.Money -= Movie.Price;
            Console.WriteLine($"Welcome {person.Name}, please enjoy the movie {Movie.Name}!");
        }
    }
}

namespace Assignment3
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
            Console.WriteLine($"Welcome {person.Name}, please enjoy the movie {Movie.Name}!");
        }
    }
}

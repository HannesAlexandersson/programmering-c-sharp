using Assignment3;

var movie = new Movie()
{
    Name = "Ghostbusters",
    AgeRating = 11,
    Price = 60
};

var cinema = new Cinema()
{
    Movie = movie
};

var person = new Person()
{
    Name = "Guybrush",
};

cinema.ShowMovieTo(person);

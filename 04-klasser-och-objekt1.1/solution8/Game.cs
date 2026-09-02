namespace Assignment8
{
    public class Game
    {
        public int Correct { get; set; }

        public int GuessNumber(int guess)
        {
            if (guess < Correct)
            {
                Console.WriteLine("too low");
                return -1;
            }

            if (guess > Correct)
            {
                Console.WriteLine("too high");
                return 1;
            }

            return 0;
        }
    }
}

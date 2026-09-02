namespace Assignment8
{
    public class Computer
    {
        public int Low = 1;
        public int High = 100;

        public void Update(int result, int guess)
        {
            if (result < 0 && guess >= Low)
            {
                Low = guess + 1;
                return;
            }

            if (result > 0 && guess <= High)
            {
                High = guess - 1;
                return;
            }
        }
    }
}

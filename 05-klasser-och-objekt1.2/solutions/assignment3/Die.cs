namespace Assignment3
{
    public static class Die
    {
        private static readonly Random Random = new Random();
        public static int Roll() => Random.Next(1, 7);
    }
}

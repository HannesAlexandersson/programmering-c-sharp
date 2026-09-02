namespace Assignment6
{
    public class Box
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public void Draw(ConsoleColor color)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            for (var row = 0; row < Height; row++)
            {
                for (var column = 0; column < Width; column++)
                {
                    Console.SetCursorPosition(X+column, Y+row);
                    Console.Write("X");
                }
            }
            Console.ForegroundColor = originalColor;
        }
    }
}

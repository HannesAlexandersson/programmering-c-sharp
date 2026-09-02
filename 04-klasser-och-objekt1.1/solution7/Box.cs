namespace Assignment7
{
    public class Box
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public void Draw(ConsoleColor color)
        {
            var originalColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
            for (var row = 0; row < Height; row++)
            {
                Console.SetCursorPosition(X, Y+row);
                Console.Write(new string(' ', Width));
            }
            Console.BackgroundColor = originalColor;
        }
    }
}

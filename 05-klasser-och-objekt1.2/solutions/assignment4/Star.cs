using Console = System.Console;

namespace Assignment4
{
    public class Star
    {
        private readonly Random _random;
        private int _x;
        private int _y;
        private int _xDirection;
        private int _yDirection;

        public Star()
        {
            _random = new Random();

            _x = _random.Next(0, Console.WindowWidth);
            _y = _random.Next(0, Console.WindowHeight);

            var directions = new [] { -1, 1 };
            _xDirection = directions[_random.Next(0, 2)];
            _yDirection = directions[_random.Next(0, 2)];
        }

        public void Move()
        {
            var newPositionX = _x + _xDirection;

            if (IsOutsideBounds(newPositionX, 0, Console.WindowWidth))
            {
                _xDirection *= -1;
                newPositionX = _x + _xDirection;
            }

            var newPositionY = _y + _yDirection;
            if (IsOutsideBounds(newPositionY, 0, Console.WindowHeight))
            {
                _yDirection *= -1;
                newPositionY = _y + _yDirection;
            }

            _x = newPositionX;
            _y = newPositionY;

            Console.SetCursorPosition(_x, _y);
            SetRandomColor();
            Console.Write('*');

            Thread.Sleep(10);
        }

        private void SetRandomColor()
        {
            var color = (ConsoleColor)_random.Next(1, 16);
            Console.ForegroundColor = color;
        }

        private static bool IsOutsideBounds(int position, int firstBound, int secondBound)
        {
            return position < firstBound || position >= secondBound;
        }
    }
}

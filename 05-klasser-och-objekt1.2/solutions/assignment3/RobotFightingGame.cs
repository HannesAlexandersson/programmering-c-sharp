namespace Assignment3
{
    public class RobotFightingGame
    {
        public Robot PlayerOne { get; }
        public Robot PlayerTwo { get; }

        public bool GameOver { get; set; }
        public string? Winner { get; set; }

        public RobotFightingGame(Robot playerOne, Robot playerTwo)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        public void NextRound()
        {
            PlayerOne.Attack(PlayerTwo);
            PlayerTwo.Attack(PlayerOne);

            GameOver = PlayerOne.Health <= 0 || PlayerTwo.Health <= 0;

            if (!GameOver)
            {
                return;
            }

            if (PlayerOne.Health > 0)
            {
                Winner = PlayerOne.Name;
            }

            if (PlayerTwo.Health > 0)
            {
                Winner = PlayerTwo.Name;
            }
        }
    }
}

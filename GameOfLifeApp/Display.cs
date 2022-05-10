namespace GameOfLifeApp
{
    /// <summary>
    /// Displays 2 boolean values arrays. 
    /// </summary>
    public class Display
    {
        /// <summary>
        /// Prints appropriate element in the random array. Displays iterated arrays. 
        /// </summary>
        /// <param name="gameData">Logic of value generating.</param>        
        public void ShowIteration(GameLogic gameLogic)
        {
            int count = 0;
            int sum = 0;
            var initialColor = Console.ForegroundColor;
            for (int row = 0; row < gameLogic.CountOfRows; row++)
            {
                for (int column = 0; column < gameLogic.CountOfColumns; column++)
                {
                    Console.ForegroundColor = gameLogic.CurrentField[row, column] ? ConsoleColor.Red : ConsoleColor.White;
                    Console.Write(gameLogic.CurrentField[row, column] ? " \u263A" : " -");

                    if (gameLogic.CurrentField[row, column])
                    {
                        count++;
                        sum = count;
                    }
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = initialColor;
            Console.WriteLine();
            Console.WriteLine($"The count of live cells in the last iteration is {sum}. ");

        }
    }
}

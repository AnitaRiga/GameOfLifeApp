namespace GameOfLifeApp
{
    /// <summary>
    /// Displays 2 boolean values arrays. 
    /// </summary>
    public class Display : IDisplay
    {
        private IGameField pr;

        public Display(IGameField properties)
        {
            pr = properties;
        }
        /// <summary>
        /// Prints appropriate element in the random array. Displays iterated arrays. 
        /// </summary>
        /// <param name="gameData">Logic of value generating.</param>        
        public void ShowIteration(IGameField pr)
        {
            const string emoji = " \u263A";
            var initialColor = Console.ForegroundColor;
            for (int row = 0; row < pr.CountOfRows; row++)
            {
                for (int column = 0; column < pr.CountOfColumns; column++)
                {
                    Console.ForegroundColor = pr.CurrentField[row, column] ? ConsoleColor.Red : ConsoleColor.White;
                    Console.Write(pr.CurrentField[row, column] ? emoji : " -");                   
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = initialColor;
            Console.WriteLine();
        }

        /// <summary>
        /// Counts alive cells in each iteration.
        /// </summary>
        /// <param name="gameLogic"></param>
        public void CountAliveCells(IGameField pr)
        {
            int aliveCellsCount = 0;
            for (int row = 0; row < pr.CountOfRows; row++)
            {
                for (int column = 0; column < pr.CountOfColumns; column++)
                {
                    if (pr.CurrentField[row, column])
                    {
                        aliveCellsCount++;
                    }
                }                
            }

            Console.WriteLine($"The count of alive cells is {aliveCellsCount}.");
        }
    }
}
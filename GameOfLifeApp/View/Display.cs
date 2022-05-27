namespace GameOfLifeApp
{
    /// <summary>
    /// Displays 2 boolean values arrays. 
    /// </summary>
    public class Display : IDisplay
    {
        /// <summary>
        /// Prints appropriate element in the random array. Displays iterated arrays. 
        /// </summary>
        /// <param name="gameData">Logic of value generating.</param>        
        public void ShowIteration(IGameField field)
        {
            const string emoji = " \u263A";
            var initialColor = Console.ForegroundColor;
            for (int row = 0; row < field.CountOfRows; row++)
            {
                for (int column = 0; column < field.CountOfColumns; column++)
                {
                    Console.ForegroundColor = field.CurrentField[row, column] ? ConsoleColor.Red : ConsoleColor.White;
                    Console.Write(field.CurrentField[row, column] ? emoji : " -");                   
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
        public int CountAliveCells(IGameField field)
        {
            int aliveCellsCount = 0;
            for (int row = 0; row < field.CountOfRows; row++)
            {
                for (int column = 0; column < field.CountOfColumns; column++)
                {
                    if (field.CurrentField[row, column])
                    {
                        aliveCellsCount++;
                    }
                }
            }
            return aliveCellsCount;
            
            //Console.WriteLine($"The count of alive cells is {aliveCellsCount}.");
        }
    }
}
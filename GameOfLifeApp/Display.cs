using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeApp
{
    /// <summary>
    /// Displays 2 boolean values array. 
    /// </summary>
    public class Display
    {
        /// <summary>
        /// Insert appropriate element in the array.
        /// </summary>
        /// <param name="gameData">logic of value generating</param>
        public static void ShowData(GameLogic gameLogic)
        {
            for (int row = 0; row < gameLogic.countOfRows; row++)
            {
                for (int column = 0; column < gameLogic.countOfColumns; column++)
                {
                    Console.WriteLine(gameLogic.currentField[row,column] ? "$" : "*");
                }
                Console.WriteLine();
            }
        }
    }
}

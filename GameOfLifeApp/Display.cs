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
        /// Prints appropriate element in the array.
        /// </summary>
        /// <param name="gameData">logic of value generating</param>
        public static void ShowData(GameLogic gameLogic)
        {
            for (int row = 0; row < gameLogic.CountOfRows; row++)
            {
                for (int column = 0; column < gameLogic.CountOfColumns; column++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(gameLogic.GeneratedField[row,column] ? " $ " : " * ");
                }
                Console.WriteLine();
            }
        }

        public static void ShowIteration(GameLogic gameLogic)
        {
            for (int row = 0; row < gameLogic.CountOfRows; row++)
            {
                for (int column = 0; column < gameLogic.CountOfColumns; column++)
                {
                    Console.ForegroundColor = gameLogic.CurrentField[row, column] ? ConsoleColor.Red : ConsoleColor.White;
                    Console.Write(gameLogic.CurrentField[row, column] ? " \u263A " : " - ");
                }
                Console.WriteLine();
            }
        }
    }
}

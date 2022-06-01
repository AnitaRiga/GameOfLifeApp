using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var initialColor = Console.ForegroundColor;  
            for (int row = 0; row < gameLogic.CountOfRows; row++)
            {
                for (int column = 0; column < gameLogic.CountOfColumns; column++)
                {
                    Console.ForegroundColor = gameLogic.CurrentField[row, column] ? ConsoleColor.Red : ConsoleColor.White;
                    Console.Write(gameLogic.CurrentField[row, column] ? "\u263A " : "- ");
                }  

                Console.WriteLine();
            }

            Console.ForegroundColor = initialColor;           
        }
    }
}

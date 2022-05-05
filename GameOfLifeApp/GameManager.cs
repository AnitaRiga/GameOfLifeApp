using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLifeApp;

namespace GameOfLifeApp
{
    /// <summary>
    /// Starts iteration.
    /// </summary>
    public class GameManager
    {
        public GameLogic? data; 
               
        /// <summary>
        /// Iteration goes on until pressing stop key.
        /// </summary>
        public void GetIteration()
        {
            int countOfRows = Communicator.GetBoundedResponse("Please input number of rows.", 2, 100);
            int countOfColumns = Communicator.GetBoundedResponse("Please input number of columns.", 2, 100);
            data = new GameLogic(countOfRows, countOfColumns);

            data.SetUpField();

            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                data.GetNextGeneration();
                //data.TransferNextGenerations();
                Display.ShowData(data);
                Thread.Sleep(1000);              

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                    break;
            }
        }
    }
}
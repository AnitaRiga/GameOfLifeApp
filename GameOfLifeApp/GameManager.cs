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
        public Communicator? communicator;
        public Display? display;
        public Serializer? serializer;

        /// <summary>
        /// Runs the game.
        /// </summary>
        public void RunGame()
        {
            Console.Title = "Game Of Life.";

            communicator = new Communicator();
            serializer = new Serializer();

            int countOfRows = communicator.GetBoundedResponse("Please input number of rows.", 2, 100);
            int countOfColumns = communicator.GetBoundedResponse("Please input number of columns.", 2, 100);
            int iterationCounter = 0;

            data = new GameLogic(countOfRows, countOfColumns);
            data.SetUpField();

            display = new Display();
            display.ShowIteration(data);

            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                data.GetNextGeneration();
                display.ShowIteration(data);
                //data.CountAliveCells();
                Thread.Sleep(1000);
                serializer.SaveData(data);

                iterationCounter++;

                Console.Title = ($"The count of iterations is {iterationCounter}.");

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            Console.WriteLine($"The total count of iterations is {iterationCounter}.");
        }
    }
}

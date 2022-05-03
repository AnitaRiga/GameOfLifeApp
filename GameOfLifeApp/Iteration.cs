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
    public class Iteration
    {
        public GameLogic data; 
        public Iteration()
        {
            data = new GameLogic();
        }
        
        /// <summary>
        /// Iteration goes on until pressing stop key.
        /// </summary>
        public void GetIteration()
        {
            data.SetUpField();

            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                data.GetNextGeneration();
                data.TransferNextGenerations();
                Display.ShowData(data);
                Thread.Sleep(1000);

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                    break;
            }
        }
    }
}
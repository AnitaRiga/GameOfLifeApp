using System;

namespace GameOfLifeApp
{
    /// <summary>
    /// Starts iteration.
    /// </summary>
    public class GameManager : IGameManager
    {
        //GameManager class class depends on the following classes.
        private IGameLogic data;
        private ICommunicator input;
        private IDisplay screen;
        private ISerializer dataBase;
               
        //Constructor accepts parameters of the dependency object type.
        //These parameters can accept any concrete class objects that implements interfaces.
        //We are passing the object of class as a parameter to the constructor of the GameManager class = 
        //= injecting the dependency object through the constructor.
        public GameManager(ICommunicator receiving, IDisplay printable, IGameLogic gameLogic, ISerializer serializer)
        {
            input = receiving;
            screen = printable;
            data = gameLogic;
            dataBase = serializer;
        }

        /// <summary>
        /// Runs the game.
        /// </summary>
        public void RunGame(IGameField pr)
        {
            int countOfRows = input.GetBoundedResponse("Please input number of rows.", 2, 100);
            int countOfColumns = input.GetBoundedResponse("Please input number of columns.", 2, 100);
            int iterationCounter = 0;

            pr.CountOfRows = countOfRows;
            pr.CountOfColumns = countOfColumns;
            data.SetUpField(pr);            

            while (true)
            {                
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                data.GetNextGeneration(pr);
                screen.ShowIteration(pr);
                screen.CountAliveCells(pr);
                iterationCounter++;
                Console.WriteLine($"The count of iterations is {iterationCounter}.");
                Thread.Sleep(1000);
                dataBase.SaveData(pr);

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    break;
                }     
            }

            Console.WriteLine($"The total count of iterations is {iterationCounter}.");
        }
    }
}

using System;

namespace GameOfLifeApp
{
    /// <summary>
    /// Starts iteration.
    /// </summary>
    public class GameManager : IGameManager
    {
        //GameManager class class depends on the following classes.
        private IGameLogic logic;
        private ICommunicator chat;
        private IDisplay print;
        private ISerializer converter;

        //Constructor accepts parameters of the dependency object type.
        //These parameters can accept any concrete class objects that implements interfaces.
        //We are passing the object of class as a parameter to the constructor of the GameManager class = 
        //= injecting the dependency object through the constructor.
        public GameManager(ICommunicator communicator, IDisplay display, IGameLogic gameLogic, ISerializer serializer)
        {
            chat = communicator;
            print = display;
            logic = gameLogic;
            converter = serializer;
        }

        /// <summary>
        /// Runs the game.
        /// </summary>
        public void RunGame(IGameField field)
        {
            int countOfRows = chat.GetBoundedResponse("Please input number of rows.", 2, 100);
            int countOfColumns = chat.GetBoundedResponse("Please input number of columns.", 2, 100);
            int iterationCounter = 0;

            field.CountOfRows = countOfRows;
            field.CountOfColumns = countOfColumns;
            logic.SetUpField(field);            

            while (true)
            {                
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                logic.GetNextGeneration(field);
                print.ShowIteration(field);
                print.CountAliveCells(field);
                //Console.WriteLine($"The count of alive cells is {aliveCelssCount}.");
                iterationCounter++;
                Console.WriteLine($"The count of iterations is {iterationCounter}.");
                Thread.Sleep(1000);
                converter.SaveData(field);

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    break;
                }     
            }
        }
    }
}

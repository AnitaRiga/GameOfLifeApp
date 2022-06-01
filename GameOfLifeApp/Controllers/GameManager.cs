using System;

namespace GameOfLifeApp
{
    /// <summary>
    /// Starts iteration.
    /// </summary>
    public class GameManager : IGameManager
    {
        //GameManager class depends on the following classes.
        private IGameLogic _gameLogic;
        private ICommunicator _communicator;
        private IDisplay _display;
        private ISerializer _serializer;

        //Constructor accepts parameters of the dependency object type.
        //These parameters can accept any concrete class objects that implements interfaces.
        //We are passing the object of class as a parameter to the constructor of the GameManager class = 
        //= injecting the dependency object through the constructor.
        public GameManager(ICommunicator communicator, IDisplay display, IGameLogic gameLogic, ISerializer serializer)
        {
            _communicator = communicator;
            _display = display;
            _gameLogic = gameLogic;
            _serializer = serializer;
        }

        /// <summary>
        /// Runs the game.
        /// </summary>
        /// <param name="field">Game field.</param>
        /// <param name="isNewGame">Whether the game is new or the stopped game.</param>
        public void RunGame(IGameField field, bool isNewGame)
        {          
            if (isNewGame)
            {
                int countOfRows = _communicator.GetBoundedResponse("Please input number of rows.", 2, 100);
                int countOfColumns = _communicator.GetBoundedResponse("Please input number of columns.", 2, 100);

                field.CountOfRows = countOfRows;
                field.CountOfColumns = countOfColumns;
                field.CountIteration = 0;
                _gameLogic.SetUpField(field);
            }
         
            while (true)
            {                
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                _gameLogic.GetNextGeneration(field);
                _display.ShowIteration(field);

                _gameLogic.CountAliveCells(field);
                object aliveCellsCount = _gameLogic.CountAliveCells(field);
                Console.WriteLine($"The count of alive cells is {aliveCellsCount}.");

                field.CountIteration++;
                Console.WriteLine($"The count of iterations is {field.CountIteration}.");

                Thread.Sleep(1000);
                _serializer.SaveData(field);

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}

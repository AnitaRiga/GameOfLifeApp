using System;

namespace GameOfLifeApp
{
    /// <summary>
    /// Manages a game.
    /// </summary>
    public class ApplicationManager : IApplicationManager
    {
        private ICommunicator chat;
        private ISerializer converter;
        private IGameManager manager;
        private IGameField field;
  
        public ApplicationManager(Communicator communicator, Serializer serializer, GameManager gameManager)
        {
            chat = communicator;
            converter = serializer;
            manager = gameManager;
        }               

        /// <summary>
        /// Manages the running app.
        /// </summary>
        public void RunApplication()
        {
            field = new GameField();
            bool isApplicationRunning = true;
            while (isApplicationRunning)
            {
                chat.StartPage();
                switch (Console.ReadLine())
                {                    
                    case "1":
                        manager.RunGame(field, true); 
                        break;
                    case "2":
                        converter.SaveData(field); 
                        manager.RunGame(field, false);
                        break;
                    default:
                        isApplicationRunning = false;
                        break;
                }
            }

            Console.WriteLine();
        }
    }
}

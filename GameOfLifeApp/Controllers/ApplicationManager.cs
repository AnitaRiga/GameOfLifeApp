using System;

namespace GameOfLifeApp
{
    /// <summary>
    /// Manages a game.
    /// </summary>
    public class ApplicationManager : IApplicationManager
    {
        /// <summary>
        /// Manages the running app.
        /// </summary>
        public void RunApplication(ICommunicator communicator, ISerializer serializer, IGameManager gameManager)
        {
            GameField field = new GameField();
            bool isApplicationRunning = true;
            while (isApplicationRunning)
            {
                communicator.StartPage();
                switch (Console.ReadLine())
                {                    
                    case "1":
                        gameManager.RunGame(field, true); 
                        break;
                    case "2":
                        serializer.SaveData(field);
                        gameManager.RunGame(field, false);
                        break;
                    case "3":
                        field = serializer.Load();
                        gameManager.RunGame(field, false);                        
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

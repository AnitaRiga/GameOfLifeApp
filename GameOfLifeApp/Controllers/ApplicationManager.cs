using System;

namespace GameOfLifeApp
{
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
                        manager.RunGame(field); 
                        break;
                    case "2":
                        converter.SaveData(field);
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

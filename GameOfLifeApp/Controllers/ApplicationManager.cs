using System;

namespace GameOfLifeApp
{
    public class ApplicationManager : IApplicationManager
    {
        private ICommunicator input;
        private IGameLogic data;
        private ISerializer dataBase;
        private IGameManager manager;
        private IGameField pr;
  
        public ApplicationManager(Communicator communicator, GameLogic gameLogic, Serializer serializer, GameManager gameManager)
        {
            input = communicator;
            data = gameLogic;
            dataBase = serializer;
            manager = gameManager;
        }               

        public void RunApplication()
        {
            pr = new GameField();
            bool isApplicationRunning = true;
            while (isApplicationRunning)
            {
                input.StartPage();
                switch (Console.ReadLine())
                {                    
                    case "1":
                        manager.RunGame(pr); 
                        break;
                    case "2":
                        dataBase.SaveData(pr);
                        break;
                    default:
                        isApplicationRunning = false;
                        break;
                }
            }

            Console.WriteLine();
        }

        public void RunApplication(int countOfRows, int countOfColumns)
        {
          data = new GameLogic();
        }
    }
}

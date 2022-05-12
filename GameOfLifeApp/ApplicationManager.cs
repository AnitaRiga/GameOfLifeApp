using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeApp
{
    public class ApplicationManager
    {
        public Serializer serializer;
        public Communicator communicator;
        public GameLogic data;
        public ApplicationManager()
        {
            data = new GameLogic(0,0);
        }
        public void RunApplication()
        {
            var gameManager = new GameManager();
            var serializer = new Serializer();
            var communicator = new Communicator();
                
            bool isApplicationRunning = true;
            while (isApplicationRunning)
            {
                communicator.StartPage();
                switch (Console.ReadLine())
                {                    
                    case "1":
                        gameManager.RunGame(); 
                        break;
                    case "2":
                        serializer.SaveData(data);
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

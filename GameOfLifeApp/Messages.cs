using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeApp
{
    public class Messages
    {
        public const string gameOptions = "Please select:" + "\n" +
                "1 for running a game;" + "\n" +
                "2 for saving the data;" + "\n" +
                "3 for continuing the last saved game;" + "\n" +
                "4 for running multiple games;" + "\n" +
                "5 for changing 8 games on the screen;" + "\n" +
                "6 for saving the data of multiple games." + "\n" + "\n" +
                "If you want to stop the game, please press the Enter key." + "\n" +
                "If you want to leave the game, please press the Enter key twice." + "\n";

        public const string userInputOfCountOfRows = "Please input number of rows from 2 to 30.";
        public const string userInputOfCountOfColumns = "Please input number of columns from 2 to 30.";
        public const string userInputCheck = "Please make sure whether you have entered a number more than {0} and less than {1}." + "\n" + "Press any key to continue.";
        public const string inputOfGamesId = "Input Id Games to be displayed.";        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeApp
{
    public class GameLogic
    {
        bool[,] generatedField;
        /// <summary>
        /// Holds user data of array size.    
        /// </summary>
        public int countOfRows { get; set; }
        public int countOfColumns { get; set; }
        public bool[,] currentField {get; set; }

        /// <summary>
        /// Gets data from user.
        /// </summary>
        public GameLogic()
        {
            countOfRows = Communicator.GetBoundedResponse("Please input number of rows.", 2, 100);
            countOfColumns = Communicator.GetBoundedResponse("Please input number of columns.", 2, 100);
            currentField = new bool[countOfRows, countOfColumns];
            generatedField = new bool[countOfRows, countOfColumns];
        }

        /// <summary>
        /// Generates a start array of random values according to user`s input.
        /// </summary>
        public void SetUpField()
        {
            Random random = new Random();
            for (int row = 0; row < countOfRows; row++) 
            {
                for (int column = 0; column < countOfColumns; column++)
                {
                    currentField[row, column] = random.Next(0, 2) == 0;
                }
            }
        }
    }
}

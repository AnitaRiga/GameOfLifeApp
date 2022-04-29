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
        public bool[,] currentField { get; set; }

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

        /// <summary>
        /// Gets number of alive cells around a given cell. 
        /// </summary>
        /// <param name="currentRow">Row of a current cell.</param>
        /// <param name="currentColumn">Column of a current cell.</param>
        /// <returns>Return number of alive neighbours.</returns>
        private int NeighboursCount(int currentRow, int currentColumn)
        {
            int count = 0;
            for (int row = currentRow - 1; row <= currentRow + 1; row++)
            {
                for (int column = currentColumn - 1; column <= currentColumn +1; column++)
                {
                    int actualRow;
                    int actualColumn;
                    if (row < 0)
                    {
                        actualRow = currentField.GetLength(0) - 1;
                    }
                    else if (row == currentField.GetLength(0))
                    {
                        actualRow = 0;
                    }
                    else
                    {
                        actualRow = row;
                    }
                    if (column < 0)
                    {
                        actualColumn = currentField.GetLength(1) - 1;
                    }
                    else if (column == currentField.GetLength(1))
                    {
                        actualColumn = 0;
                    }
                    else
                    {
                        actualColumn = column;
                    }
                    count += currentField[actualRow, actualColumn] ? 1 : 0;
                }
            }
            count -= currentField[currentRow, currentColumn] ? 1 : 0;

            return count;
        }

        /// <summary>
        /// Gets new boolean values according to statements.
        /// </summary>
        /// <param name="neighboursCount">Number of alive cells around a given cell.</param>
        /// <param name="isCurrentAlive">Given cell is alive. Value of isCurrentAlive: true.</param>
        /// <returns>Return the next value for a given cell.</returns>
        private bool GetCellOffsprings(int neighboursCount, bool isCurrentAlive)
        {
            if (!isCurrentAlive && neighboursCount == 3)
            {
                return true;
            }
            else if (isCurrentAlive && neighboursCount == 2 || neighboursCount == 3)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method generates a new field.       
        /// </summary>
        public void GetNextGeneration()
        {
            for (int row = 0; row < countOfRows; row++)
            {
                for (int column = 0; column < countOfColumns; column++)
                {
                    int count = NeighboursCount(row, column);
                    bool value = GetCellOffsprings(count, currentField[row, column]);  

                    generatedField[row, column] = value;
                }
            }
        }

        /// <summary>
        ///  Transfer data to a generated field.       
        /// </summary>
        public void TransferNextGenerations()
        {
            for (int row = 0; row < countOfRows; row++)
            {
                for (int column = 0; column < countOfColumns; column++)
                {
                    currentField[row, column] = generatedField[row, column];
                }
            }
        }
    }
}

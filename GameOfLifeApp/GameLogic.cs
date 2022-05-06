using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeApp
{
    public class GameLogic
    {
        /// <summary>
        /// Declares a 2D array without specifying its size.   
        /// </summary>
        public bool[,] GeneratedField;

        /// <summary>
        /// Holds user data of array size.    
        /// </summary>        
        public int CountOfRows { get; set; }

        /// <summary>
        /// Holds user data of array size. 
        /// </summary>        
        public int CountOfColumns { get; set; }

        /// <summary>
        /// Currently active game field.
        /// </summary>        
        public bool[,] CurrentField { get; set; }

        /// <summary>
        /// Defines array size.
        /// </summary>        
        public GameLogic(int rows, int columns)
        {
            //CountOfRows = Communicator.GetBoundedResponse("Please input number of rows.", 2, 100);
            //CountOfColumns = Communicator.GetBoundedResponse("Please input number of columns.", 2, 100);
            CurrentField = new bool[rows, columns];
            GeneratedField = new bool[rows, columns];

            CountOfRows = rows;
            CountOfColumns = columns;
        }

        /// <summary>
        /// Generates a start array of random values according to user`s input.
        /// </summary>
        public void SetUpField()
        {
            // Instantiate random number generator
            Random rnd = new Random();

            for (int row = 0; row < CountOfRows; row++)
            {
                for (int column = 0; column < CountOfColumns; column++)
                {
                    GeneratedField[row, column] = rnd.Next(0, 2) == 0;
                }
            }
            CurrentField = GeneratedField;
        }

        /// <summary>
        /// populates the field with Glider the Shape. 
        /// </summary>
        public void CreateGliderShape()
        {
            CurrentField[0, 0]= true;
            CurrentField[2, 0] = true;
            CurrentField[1, 1] = true;
            CurrentField[2, 1] = true;
            CurrentField[1, 2] = true;
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
                        actualRow = CurrentField.GetLength(0) - 1;
                    }
                    else if (row == CurrentField.GetLength(0))
                    {
                        actualRow = 0;
                    }
                    else
                    {
                        actualRow = row;
                    }
                    if (column < 0)
                    {
                        actualColumn = CurrentField.GetLength(1) - 1;
                    }
                    else if (column == CurrentField.GetLength(1))
                    {
                        actualColumn = 0;
                    }
                    else
                    {
                        actualColumn = column;
                    }
                    count += CurrentField[actualRow, actualColumn] ? 1 : 0;
                }
            }
            count -= CurrentField[currentRow, currentColumn] ? 1 : 0;

            return count;
        }

        /// <summary>
        /// Gets new boolean values according to statements.
        /// </summary>
        /// <param name="neighboursCount">Number of alive cells around a given cell.</param>
        /// <param name="isCurrentAlive">Given cell is alive. Value of isCurrentAlive: true.</param>
        /// <returns>Return the next value for a given cell.</returns>
        private static bool GetCellOffsprings(int neighboursCount, bool isCurrentAlive)
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
        /// This method generates a new field and transfers data to a generated field.       
        /// </summary>
        public void GetNextGeneration()
        {
            bool[,] generatedField2 = new bool[CountOfRows, CountOfColumns];

            for (int row = 0; row < CountOfRows; row++)
            {
                for (int column = 0; column < CountOfColumns; column++)
                {
                    int count = NeighboursCount(row, column);
                    bool value = GetCellOffsprings(count, CurrentField[row, column]);  

                    generatedField2[row, column] = value;                    
                }
            }
            CurrentField = generatedField2;
        }
    }
}

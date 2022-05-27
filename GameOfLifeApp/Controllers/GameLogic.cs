using System;

namespace GameOfLifeApp 
{
    public class GameLogic : IGameLogic
    {
        /// <summary>
        /// Generates a start array of random values according to user`s input.
        /// </summary>
        public void SetUpField(IGameField field)
        {                
            Random rnd = new Random();

            bool[,] GeneratedField = new bool[field.CountOfRows, field.CountOfColumns];

            for (int row = 0; row < field.CountOfRows; row++)
            {
                for (int column = 0; column < field.CountOfColumns; column++)
                {
                    GeneratedField[row, column] = rnd.Next(0, 2) == 0;
                }
            }
            field.CurrentField = GeneratedField;
        }

        /// <summary>
        /// Populates the field with Glider the Shape. 
        /// </summary>
        public void CreateGliderShape(IGameField pr)
        {
            pr.CurrentField[0, 0] = true;
            pr.CurrentField[2, 0] = true;
            pr.CurrentField[1, 1] = true;
            pr.CurrentField[2, 1] = true;
            pr.CurrentField[1, 2] = true;
        }

        /// <summary>
        /// Gets number of alive cells around a given cell. 
        /// </summary>
        /// <param name="currentRow">Row of a current cell.</param>
        /// <param name="currentColumn">Column of a current cell.</param>
        /// <returns>Returns number of alive neighbours.</returns>
        private int NeighboursCount(IGameField field, int currentRow, int currentColumn)
        {
            int count = 0;
            int actualRow;
            int actualColumn;

            for (int row = currentRow - 1; row <= currentRow + 1; row++)
            {
                for (int column = currentColumn - 1; column <= currentColumn + 1; column++)
                {
                    if (row < 0)
                    {
                        actualRow = field.CurrentField.GetLength(0) - 1;
                    }
                    else if (row == field.CurrentField.GetLength(0))
                    {
                        actualRow = 0;
                    }
                    else
                    {
                        actualRow = row;
                    }
                    if (column < 0)
                    {
                        actualColumn = field.CurrentField.GetLength(1) - 1;
                    }
                    else if (column == field.CurrentField.GetLength(1))
                    {
                        actualColumn = 0;
                    }
                    else
                    {
                        actualColumn = column;
                    }
                    count += field.CurrentField[actualRow, actualColumn] ? 1 : 0;
                }
            }
            count -= field.CurrentField[currentRow, currentColumn] ? 1 : 0;

            return count;
        }

        /// <summary>
        /// Gets new boolean values according to statements.
        /// </summary>
        /// <param name="neighboursCount">Number of alive cells around a given cell.</param>
        /// <param name="isCurrentAlive">Given cell is alive. Value of isCurrentAlive: true.</param>
        /// <returns>Returns the next value for a given cell.</returns>
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
        /// This method generates a new field and transfers data to a generated field.       
        /// </summary>
        public void GetNextGeneration(IGameField field)
        {
            bool[,] generatedField = new bool[field.CountOfRows, field.CountOfColumns];

            for (int row = 0; row < field.CountOfRows; row++)
            {
                for (int column = 0; column < field.CountOfColumns; column++)
                {
                    int countAliveNeighbours = NeighboursCount(field, row, column);

                    generatedField[row, column] = GetCellOffsprings(countAliveNeighbours, field.CurrentField[row, column]);
                }
            }

            field.CurrentField = generatedField;
        }
    }
}

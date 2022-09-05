namespace GameOfLifeApp
{
    /// <summary>
    /// Generates fields.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        /// <summary>
        /// Generates a start array of random values according to user`s input.
        /// </summary>
        public void SetUpField(IGameField field)
        {
            Random random = new Random();

            bool[,] InitialField = new bool[field.CountOfRows, field.CountOfColumns];

            for (int row = 0; row < field.CountOfRows; row++)
            {
                for (int column = 0; column < field.CountOfColumns; column++)
                {
                    InitialField[row, column] = random.Next(0, 2) == 0;
                }
            }
            field.CurrentField = InitialField;
        }

        /// <summary>
        /// Populates the field with Glider the Shape.
        /// </summary>
        public void CreateGliderShape(IGameField field)
        {
            field.CurrentField[0, 0] = true;
            field.CurrentField[2, 0] = true;
            field.CurrentField[1, 1] = true;
            field.CurrentField[2, 1] = true;
            field.CurrentField[1, 2] = true;
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

            for (int row = currentRow - 1; row <= currentRow + 1; row++)
            {
                for (int column = currentColumn - 1; column <= currentColumn + 1; column++)
                {
                    int actualRow = (row + field.CurrentField.GetLength(0)) % field.CurrentField.GetLength(0);
                    int actualColumn = (column + field.CurrentField.GetLength(1)) % field.CurrentField.GetLength(1);

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

        /// <summary>
        /// Counts alive cells in each iteration.
        /// </summary>
        /// <param name="field">Current field.</param>
        /// <returns>Alive cells count.</returns>
        public int CountAliveCells(IGameField field)
        {
            int aliveCellsCount = 0;
            for (int row = 0; row < field.CountOfRows; row++)
            {
                for (int column = 0; column < field.CountOfColumns; column++)
                {
                    if (field.CurrentField[row, column])
                    {
                        aliveCellsCount++;
                    }
                }
            }

            return aliveCellsCount;
        }
    }
}

namespace GameOfLifeApp
{
  /// <summary>
  /// Displays 2 boolean values arrays. 
  /// </summary>
  public class Display : IDisplay
  {
    /// <summary>
    /// Prints appropriate element in the random array. Displays iterated arrays. 
    /// </summary>
    /// <param name="field">Logic of value generating.</param>        
    public void ShowIteration(IGameField field)
    {
      const string emoji = " \u263A";
      var initialColor = Console.ForegroundColor;
      for (int row = 0; row < field.CountOfRows; row++)
      {
        for (int column = 0; column < field.CountOfColumns; column++)
        {
          Console.ForegroundColor = field.CurrentField[row, column] ? ConsoleColor.Red : ConsoleColor.White;
          Console.Write(field.CurrentField[row, column] ? emoji : " -");
        }

        Console.WriteLine();
      }

      Console.ForegroundColor = initialColor;
      Console.WriteLine();
    }

    /// <summary>
    /// Prints selected 8 games on the screen. Displays iterated arrays. 
    /// </summary>
    /// <param name="listGames">1000 games in parallel.</param>
    public void ShowMultipleIteration(List<IGameField> listGames)
    {
      const string emoji = " \u263A";
      var initialColor = Console.ForegroundColor;

      int gamesToShow = listGames.Count - 1;

      // As I have no possibility to choose the unique size for each game, I get the size of fields from user`s input.
      int rowLength = listGames[0].CountOfRows;
      int columnHeight = listGames[0].CountOfColumns;
      int counter = -1;

      int firstArrayIndex = 0;
      int secondArrayIndex = 0;

      do
      {
        for (int row = 0; row < rowLength; row++)
        {
          for (int column = 0; column < columnHeight; column++)
          {
            if (row == 0 && column == 0)
            {
              firstArrayIndex = ++counter;
            }

            Console.ForegroundColor = listGames[firstArrayIndex].CurrentField[row, column] ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write(listGames[firstArrayIndex].CurrentField[row, column] ? emoji : " -");
          }

          Console.Write("\t");
          for (int column = 0; column < columnHeight; column++)

          {
            if (row == 0 && column == 0)
            {
              secondArrayIndex = ++counter;
            }

            Console.ForegroundColor = listGames[secondArrayIndex].CurrentField[row, column] ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write(listGames[secondArrayIndex].CurrentField[row, column] ? emoji : " -");
          }

          Console.WriteLine();
        }

        Console.ForegroundColor = initialColor;
        Console.WriteLine();
      }

      while (gamesToShow != counter);
    }
  }
}



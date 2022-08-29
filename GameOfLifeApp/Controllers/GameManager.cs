namespace GameOfLifeApp
{
  /// <summary>
  /// Starts iteration.
  /// </summary>
  public class GameManager : IGameManager
  {
    //GameManager class depends on the following classes.
    private readonly IGameLogic _gameLogic;
    private readonly ICommunicator _communicator;
    private readonly IDisplay _display;
    private readonly ISerializer _serializer;

    int minCountOfRowsOrColumns = 2;
    int maxCountOfRowsOrColumns = 30;

    //Constructor accepts parameters of the dependency object type.
    //These parameters can accept any concrete class objects that implements interfaces.
    //We are passing the object of class as a parameter to the constructor of the GameManager class = 
    //= injecting the dependency object through the constructor.
    public GameManager(ICommunicator communicator, IDisplay display, IGameLogic gameLogic, ISerializer serializer)
    {
      _communicator = communicator;
      _display = display;
      _gameLogic = gameLogic;
      _serializer = serializer;
    }

    /// <summary>
    /// Runs the game.
    /// </summary>
    /// <param name="field">Game field.</param>
    /// <param name="isNewGame">Whether the game is new or the stopped game.</param>
    public void RunGame(IGameField field, bool isNewGame)
    {
      if (isNewGame)
      {
        int countOfRows = _communicator.GetBoundedResponse($"Please input number of rows from {minCountOfRowsOrColumns} to {maxCountOfRowsOrColumns}.", minCountOfRowsOrColumns, maxCountOfRowsOrColumns);
        int countOfColumns = _communicator.GetBoundedResponse($"Please input number of rows from {minCountOfRowsOrColumns} to {maxCountOfRowsOrColumns}.", minCountOfRowsOrColumns, maxCountOfRowsOrColumns);

        field.CountOfRows = countOfRows;
        field.CountOfColumns = countOfColumns;
        field.CountIteration = 0;
        _gameLogic.SetUpField(field);
      }

      while (true)
      {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        _gameLogic.GetNextGeneration(field);
        _display.ShowIteration(field);

        _gameLogic.CountAliveCells(field);
        object aliveCellsCount = _gameLogic.CountAliveCells(field);
        Console.WriteLine($"The count of alive cells is {aliveCellsCount}.");

        field.CountIteration++;
        Console.WriteLine($"The count of iterations is {field.CountIteration}.");

        Thread.Sleep(1000);
        _serializer.SaveData(field);

        if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
        {
          break;
        }
      }
    }

    /// <summary>
    /// Runs 1000 games in parallel &  shows the selected games on the screen.
    /// </summary>
    /// <param name="games">Game fields.</param>
    /// <param name="field">Game field.</param>
    /// <param name="isNewGame">Whether the games are new or the stopped games.</param>
    public void RunMultipleGames(List<IGameField> games, IGameField field, bool isNewGame)
    {
      if (isNewGame)
      {
        int countOfRows = _communicator.GetBoundedResponse($"Please input number of rows from {minCountOfRowsOrColumns} to {maxCountOfRowsOrColumns}.", minCountOfRowsOrColumns, maxCountOfRowsOrColumns);
        int countOfColumns = _communicator.GetBoundedResponse($"Please input number of columns from {minCountOfRowsOrColumns} to {maxCountOfRowsOrColumns}.", minCountOfRowsOrColumns, maxCountOfRowsOrColumns);
        for (int gameNumber = 0; gameNumber < 1000; gameNumber++)
        {
          IGameField gameField = new GameField();
          gameField.CountOfRows = countOfRows;
          gameField.CountOfColumns = countOfColumns;
          field.CountIteration = 0;
          _gameLogic.SetUpField(gameField);
          games.Add(gameField);
        }
      }

      List<int> gamesIdsToShow = _communicator.GetGamesId("Please choose 8 games for displaying.");
      List<IGameField> gameFieldsToShow = new List<IGameField>();

      for (int i = 0; i < gamesIdsToShow.Count; i++)
      {
        gameFieldsToShow.Add(games[gamesIdsToShow[i]]);
      }

      while (true)
      {
        Console.Clear();
        Console.SetCursorPosition(0, 0);

        int displayedAliveCellsCount = 0;
        int totalAliveCellsCount = 0;
        int totalLiveGamesCount = 0;

        field.CountIteration++;

        foreach (var gameField in games)
        {
          _gameLogic.GetNextGeneration(gameField);
          _gameLogic.CountAliveCells(gameField);
          int aliveCellsCount = _gameLogic.CountAliveCells(gameField);
          int aliveCell = int.Parse(aliveCellsCount.ToString());
          totalAliveCellsCount += aliveCellsCount;
          if (aliveCell > 0)
          {
            totalLiveGamesCount++;
          }
        }

        for (int i = 0; i < gamesIdsToShow.Count; i++)
        {
          _gameLogic.CountAliveCells(gameFieldsToShow[i]);
          int aliveCellsCount = _gameLogic.CountAliveCells(gameFieldsToShow[i]);
          displayedAliveCellsCount += aliveCellsCount;
        }

        _display.ShowMultipleIteration(gameFieldsToShow);

        Console.WriteLine($"The count of iterations is {field.CountIteration}.");
        Console.WriteLine($"The count of alive cells in 8 displayed games is {displayedAliveCellsCount}.");
        Console.WriteLine($"The count of alive cells in total is {totalAliveCellsCount}.");
        Console.WriteLine($"The count of live games is {totalLiveGamesCount}.");

        Thread.Sleep(1000);
        _serializer.SaveAllGames(games, field);

        if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
        {
          break;
        }
      }
    }
  }
}

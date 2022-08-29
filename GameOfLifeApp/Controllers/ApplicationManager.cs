namespace GameOfLifeApp
{
  /// <summary>
  /// Manages a game.
  /// </summary>
  public class ApplicationManager : IApplicationManager
  {
    /// <summary>
    /// Manages the running app.
    /// </summary>
    /// <param name="communicator">The object of class Communicator = injecting the dependency object through the constructor.</param>
    /// <param name="serializer">The object of class Serializer</param>
    /// <param name="gameManager">The object of class GameManager </param>
    public void RunApplication(ICommunicator communicator, ISerializer serializer, IGameManager gameManager)
    {
      GameField field = new GameField();
      List<IGameField> games = new List<IGameField>();

      bool isApplicationRunning = true;
      while (isApplicationRunning)
      {
        communicator.StartPage();
        switch (Console.ReadLine())
        {
          case "1":
            gameManager.RunGame(field, true);
            break;
          case "2":
            serializer.SaveData(field);
            gameManager.RunGame(field, false);
            break;
          case "3":
            field = serializer.Load();
            gameManager.RunGame(field, false);
            break;
          case "4":
            gameManager.RunMultipleGames(games, field, true);
            break;
          case "5":
            gameManager.RunMultipleGames(games, field, false);
            break;
          case "6":
            serializer.SaveAllGames(games, field);
            gameManager.RunGame(field, false);
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

namespace GameOfLifeApp
{
  /// <summary>
  /// Holds data about the current field.
  /// </summary>
  public class GameField : IGameField
  {
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
    /// Current count of iterations.
    /// </summary>
    public int CountIteration { get; set; }
  }
}

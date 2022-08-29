namespace GameOfLifeApp
{
  /// <summary>
  /// Generates fields.
  /// </summary>
  public interface IGameLogic
  {
    /// <summary>
    /// Generates a start array of random values according to user`s input.
    /// </summary>
    /// <param name="field"></param>
    void SetUpField(IGameField field);

    /// <summary>
    /// This method generates a new field and transfers data to a generated field.   
    /// </summary>
    /// <param name="field"></param>
    void GetNextGeneration(IGameField field);

    /// <summary>
    /// Counts alive cells in each iteration.
    /// </summary>
    /// <param name="field">Current field.</param>
    /// <returns>Alive cells count.</returns>
    int CountAliveCells(IGameField field);
  }
}

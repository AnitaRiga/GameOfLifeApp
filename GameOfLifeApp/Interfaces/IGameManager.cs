namespace GameOfLifeApp
{
    /// <summary>
    /// Starts iteration.
    /// </summary>
    public interface IGameManager
    {
        /// <summary>
        /// Runs the game.
        /// </summary>
        /// <param name="field">Game field.</param>
        /// <param name="isNewGame">Whether the game is new or the stopped game.</param>
        void RunGame(IGameField field, bool isNewGame);
    void RunMultipleGames(List<IGameField> games, IGameField field, bool isNewGame);
   }
}
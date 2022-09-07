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

        /// <summary>
        /// Runs 1000 games in parallel &  shows the selected games on the screen.
        /// </summary>
        /// <param name="games">Game fields.</param>
        /// <param name="field">Game field.</param>
        /// <param name="isNewGame">Whether the games are new or the stopped games.</param>
        void RunMultipleGames(List<IGameField> games, IGameField field, bool isNewGame);
    }
}
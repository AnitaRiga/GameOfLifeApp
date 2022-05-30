namespace GameOfLifeApp
{
    public interface IGameManager
    {
        void RunGame(IGameField field, bool isNewGame);
    }
}
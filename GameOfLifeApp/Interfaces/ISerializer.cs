using System;

namespace GameOfLifeApp
{
    public interface ISerializer
    {
        void SaveData(IGameField pr);
    }
}

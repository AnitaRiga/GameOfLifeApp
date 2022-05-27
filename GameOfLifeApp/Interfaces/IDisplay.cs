using System;

namespace GameOfLifeApp
{
    public interface IDisplay
    {        
        void ShowIteration(IGameField field);
        int CountAliveCells(IGameField field);
    }
}

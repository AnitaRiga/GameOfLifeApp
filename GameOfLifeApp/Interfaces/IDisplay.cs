using System;

namespace GameOfLifeApp
{
    public interface IDisplay
    {        
        void ShowIteration(IGameField pr);
        void CountAliveCells(IGameField pr);
    }
}

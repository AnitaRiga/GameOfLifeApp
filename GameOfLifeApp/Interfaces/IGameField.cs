using System;

namespace GameOfLifeApp
{
    public interface IGameField
    {
        int CountOfRows { get; set; }
        int CountOfColumns { get; set; }
        bool[,] CurrentField { get; set; }
    }
}

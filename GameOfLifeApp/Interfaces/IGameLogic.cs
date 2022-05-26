using System;

namespace GameOfLifeApp
{
    public interface IGameLogic
    {
        void SetUpField(IGameField pr);        
        void GetNextGeneration(IGameField pr);       
    }
}
 
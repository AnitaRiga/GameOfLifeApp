using System;

namespace GameOfLifeApp
{
    public interface IGameLogic
    {
        void SetUpField(IGameField field);        
        void GetNextGeneration(IGameField field);       
    }
}
 
using System;

namespace GameOfLifeApp
{
    public class GameField : IGameField
    {        
        /// <summary>
        /// Holds user data of array size.    
        /// </summary>        
        public int CountOfRows { get; set; }

        /// <summary>
        /// Holds user data of array size. 
        /// </summary>        
        public int CountOfColumns { get; set; }

        /// <summary>
        /// Currently active game field.
        /// </summary>        
        public bool[,] CurrentField { get; set; }

        public int CountIteration { get; set; }
    }
}

using System;

namespace GameOfLifeApp
{
    /// <summary>
    /// Holds data about the current field.
    /// </summary>
    public interface IGameField
    {
        /// <summary>
        /// Holds user data of array size. 
        /// </summary>
        int CountOfRows { get; set; }

        /// <summary>
        /// Holds user data of array size. 
        /// </summary>
        int CountOfColumns { get; set; }

        /// <summary>
        /// Currently active game field.
        /// </summary>
        bool[,] CurrentField { get; set; }

        /// <summary>
        /// Current count of iterations.
        /// </summary>
        int CountIteration { get; set; }
    }
}

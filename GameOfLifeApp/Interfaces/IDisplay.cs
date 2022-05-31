﻿using System;

namespace GameOfLifeApp
{
    /// <summary>
    /// Displays 2 boolean values arrays. 
    /// </summary>
    public interface IDisplay
    {
        /// <summary>
        /// Prints appropriate element in the random array. Displays iterated arrays. 
        /// </summary>
        /// <param name="field">Logic of value generating.</param>        
        void ShowIteration(IGameField field);
    }
}

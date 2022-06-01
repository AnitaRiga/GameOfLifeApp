using System;

namespace GameOfLifeApp
{
    /// <summary>
    /// Saves JSON data to a file.    
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Creates a StreamWriter and adds some text to the writer using StreamWriter.
        /// </summary>
        /// <param name="field">Saves the data of the object.</param>
        void SaveData(IGameField field);

        /// <summary>
        /// Opens the file for reading and 
        /// reads all characters from the current position to the end of the stream and returns them as a single string.
        /// <returns>Field.</returns>
        GameField Load();
    }
}

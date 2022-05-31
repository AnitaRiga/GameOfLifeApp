using System;

namespace GameOfLifeApp
{
    /// <summary>
    /// Manages a game.
    /// </summary>
    public interface IApplicationManager
    {
        /// <summary>
        /// Manages the running app.
        /// </summary>
        void RunApplication(IGameField field, ICommunicator chat, ISerializer converter);
    }
}

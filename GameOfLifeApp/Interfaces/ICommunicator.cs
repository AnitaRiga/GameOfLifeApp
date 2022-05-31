using System;

namespace GameOfLifeApp
{
    /// <summary>
    /// Requests info from  user. Sends a message about incorrect input.
    /// </summary>
    public interface ICommunicator
    {
        /// <summary>
        /// Checks whether int is aligned with number range.
        /// </summary>
        /// <param name="message">User`s input.</param>
        /// <param name="minValue">Min number possible.</param>
        /// <param name="maxValue">Max number possible.</param>
        /// <returns>Returns an arraySize that equals to the count of rows / columns.</returns>
        int GetBoundedResponse(string message, int minValue, int maxValue);

        /// <summary>
        /// Informs about the response options and requests a response from a user.
        /// </summary>
        void StartPage();
    }
}

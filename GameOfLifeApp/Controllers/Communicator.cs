using GameOfLifeApp;

namespace GameOfLifeApp
{
    /// <summary>
    /// Requests info from  user. Sends a message about incorrect input.
    /// </summary>
    public class Communicator : ICommunicator
    {        
        /// <summary>
        /// Gets data from user.
        /// </summary>
        /// <param name="message">Requests to provide informatiom about array size.</param>
        /// <returns>Returns count of columns and count of rows.</returns>
        private string GetInput(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        /// <summary>
        /// Checks whether int is aligned with number range.
        /// </summary>
        /// <param name="message">User`s input.</param>
        /// <param name="minValue">Min number possible.</param>
        /// <param name="maxValue">Max number possible.</param>
        /// <returns>Returns an arraySize that equals to the count of rows / columns.</returns>
        public int GetBoundedResponse(string message, int minValue, int maxValue)
        {
            do
            {
                string userInput = GetInput(message);

                if (int.TryParse(userInput, out int arraySize) && arraySize >= minValue && arraySize <= maxValue)
                {
                    return arraySize;
                }
                else
                {
                    Console.WriteLine(string.Format(Messages.userInputCheck, minValue, maxValue));
                    Console.ReadKey();
                }
            } while (true);
        }

        /// <summary>
        /// Gets ID of games from user.
        /// </summary>
        /// <param name="message">Requests to provide ID of games.</param>
        /// <returns>List of games` ID.</returns>
        public List<int> GetGamesId(string message)
        {
            Console.WriteLine(message);
            List<int> gamesId = new List<int>();

            for (int userId = 0; userId <= 7; userId++)
            {
                int inputId = GetBoundedResponse("Input Id Games to be displayed", 0, 999);
                gamesId.Add(inputId);
            }

            return gamesId;
        }

        /// <summary>
        /// Informs about the response options and requests a response from a user.
        /// </summary>
        public void StartPage()
        {
            Console.WriteLine(Messages.chooseOption);
        }
    }
}

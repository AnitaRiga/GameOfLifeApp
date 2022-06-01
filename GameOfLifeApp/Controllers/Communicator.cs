using System;

namespace GameOfLifeApp
{
    /// <summary>
    /// Requests info from  user. Sends a message about incorrect input.
    /// </summary>
    public class Communicator : ICommunicator
    {
        const string userInputCheck = "Please make sure whether you have entered a number more than {0} and less than {1}." + "\n" + "Press any key to continue.";
       
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
                    Console.WriteLine(string.Format(userInputCheck, minValue, maxValue));
                    Console.ReadKey();
                }
            } while (true);
        }

        /// <summary>
        /// Informs about the response options and requests a response from a user.
        /// </summary>
        public void StartPage()
        {
            Console.WriteLine();
            const string option = "Please select 1 for running a game" + "\n" + 
                "2 for saving the data." + "\n" +
                "3 for continuing the last saved game." + "\n" +
                "If you want to stop the game, please press the Enter key." + "\n" + 
                "If you want to leave the game, please press the Enter key twice.";
            Console.WriteLine(option);
        }
    }
}

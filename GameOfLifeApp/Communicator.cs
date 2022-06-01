using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeApp
{
    /// <summary>
    /// Requests info from  user. Sends a message about incorrect input.
    /// </summary>
    public class Communicator
    {      
        const string notANumberMessage = "Inputed value is not a number. Please input a number. Press any key to continue.";
        const string outOfLimit = "Out of limit.";
        const string notMinMax = "Value should be more than {0} and less than {1}." + "\n" + "Press any key to continue.";

        /// <summary>
        /// Gets data from user.
        /// </summary>
        /// <param name="message">Requests to provide informatiom about array size.</param>
        /// <returns>Returns count of columns and count of rows.</returns>
        private static string GetInput(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        /// <summary>
        /// Checks the input and converts it to int. Requests to input a number.
        /// </summary>
        /// <param name="message">User`s response.</param>
        /// <returns>Returns a number that equals to the count of rows / columns.</returns>
        public int GetNumericResponse(string message)
        {  
            do
            {
                string? response = GetInput(message);

                if (int.TryParse(response, out int number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine(notANumberMessage);
                    Console.ReadKey();
                }
            } while (true);
        }

        /// <summary>
        /// Checks whether int is aligned with number range.
        /// </summary>
        /// <param name="message">User`s response.</param>
        /// <param name="minValue">Min number possible.</param>
        /// <param name="maxValue">Max number possible.</param>
        /// <returns>Returns a value that equals to the count of rows / columns.</returns>
        public int GetBoundedResponse(string message, int minValue, int maxValue)
        {            
            do
            {
                int value = GetNumericResponse(message);

                if (value >= minValue && value <= maxValue)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine(outOfLimit);
                    Console.WriteLine(string.Format(notMinMax, minValue, maxValue));
                    Console.ReadKey();
                }
            } while (true);
        }
    }
}

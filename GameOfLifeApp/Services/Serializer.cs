using Newtonsoft.Json;

namespace GameOfLifeApp
{
    /// <summary>
    /// Saves JSON data to a file.    
    /// </summary>
    public class Serializer : ISerializer
    {
        public Serializer()
        {
            //data = gameLogic;
            //pr = properties;
        }

        // Declaring a private string. Get the complete path of the current working directory. Using CurrentDirectory property of Environment class.
        private string _fileName = $"{Environment.CurrentDirectory}\\GameData.json";

        /// <summary>
        /// Creates a StreamWriter and adds some text to the writer using StreamWriter.
        /// </summary>
        /// <param name="gameLogic">Saves the data of the object.</param>
        public void SaveData(IGameField pr)
        {
            using (StreamWriter writer = File.CreateText(_fileName))
            {
                string output = JsonConvert.SerializeObject(pr);
                writer.Write(output);
            }
        }

        public void Load()
        {
            // Open the file for reading.
            using (StreamReader sr = File.OpenText(_fileName))
            {
                //Reads all characters from the current position to the end of the stream and returns them as a single string.
                string fileText = sr.ReadToEnd();
                GameField? pr = JsonConvert.DeserializeObject<GameField>(fileText);
                while ((fileText = sr.ReadLine()) != null)
                {
                    Console.WriteLine(fileText);
                }
            }
        }
    }
}

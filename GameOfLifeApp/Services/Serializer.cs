using Newtonsoft.Json;

namespace GameOfLifeApp
{
    /// <summary>
    /// Saves JSON data to a file.    
    /// </summary>
    public class Serializer : ISerializer
    {
        // Declaring a private string. Get the complete path of the current working directory. Using CurrentDirectory property of Environment class.
        private string _fileName = $"{Environment.CurrentDirectory}\\GameData.json";

        /// <summary>
        /// Creates a StreamWriter and adds some text to the writer using StreamWriter.
        /// </summary>
        /// <param name="field">Saves the data of the object.</param>
        public void SaveData(IGameField field)
        {
            using (StreamWriter writer = File.CreateText(_fileName))
            {
                string output = JsonConvert.SerializeObject(field);
                writer.Write(output);
            }
        }

        /// <summary>
        /// Opens the file for reading and 
        /// reads all characters from the current position to the end of the stream and returns them as a single string.        
        /// /// </summary>
        /// <returns>Field.</returns>
        public GameField Load()
        {
            GameField field = new GameField();
            
            using (StreamReader sr = File.OpenText(_fileName))
                {
                    string fileText = sr.ReadToEnd();
                    field = JsonConvert.DeserializeObject<GameField>(fileText);                    
                }
            
            return field;
        }
    }
}

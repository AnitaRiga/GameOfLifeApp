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

    /// <summary>
    /// Creates a StreamWriter and adds some text to the writer using StreamWriter.
    /// </summary>
    /// <param name="games">Saves the data of the object 'games'.</param>
    /// <param name="field">Saves the data of the object 'field'.</param>
    public void SaveAllGames(List<IGameField> games, IGameField field)
    {
      using (StreamWriter writer = File.CreateText(_fileName))

      {
        string serializedGames = JsonConvert.SerializeObject(games);
        string serializedCountOfIteration = JsonConvert.SerializeObject(field.CountIteration);
        var ser = new JsonSerializer();
        foreach (var item in games)
        {
          ser.Serialize(writer, "Count Of Rows: " + item.CountOfRows);
          ser.Serialize(writer, "Count Of Columns: " + item.CountOfColumns);
          ser.Serialize(writer, "Current Field:");
          ser.Serialize(writer, item.CurrentField);
          ser.Serialize(writer, "Count Of Iterations: " + field.CountIteration);
          writer.Write(Environment.NewLine);
        }
      }
    }
  }
}

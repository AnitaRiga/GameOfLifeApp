using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameOfLifeApp
{
    /// <summary>
    /// Saves JSON data to a file.    
    /// </summary>
    public class Serializer
    {
        public GameLogic? data;
        //public Display? display;

        public string fileName = @"C:\Users\a.vlasova\source\repos\AnitaRiga\GameOfLifeApp\GameData.json";

        /// <summary>
        /// Creates a StreamWriter and adds some text to the writer using StreamWriter.
        /// </summary>
        /// <param name="gameLogic">Saves the data of the object.</param>
        public void SaveData(GameLogic gameLogic)
        {
            //display = new Display();
            using (StreamWriter writer = File.CreateText(fileName))
            {
                string output = JsonConvert.SerializeObject(gameLogic);
                writer.Write(output);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace GameOfLifeApp
{
    public class Serializer
    {
        public GameLogic? data;
        //public Display? display;

        public string fileName = @"C:\Users\a.vlasova\source\repos\AnitaRiga\GameOfLifeApp\GameData.json";

        public void SaveData(GameLogic gameLogic)
        {
            //display = new Display();
            using (StreamWriter writer = File.CreateText(fileName))
            {
                string output1 = JsonConvert.SerializeObject(gameLogic);
                //string output2 = JsonConvert.SerializeObject(display);
                writer.Write(output1);
            }
        }
    }
}

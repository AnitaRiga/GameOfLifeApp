using GameOfLifeApp;

var data = new GameLogic();
data.SetUpField();

while (true)
{
    Display.ShowData(data);
}
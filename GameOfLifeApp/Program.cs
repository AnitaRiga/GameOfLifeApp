using GameOfLifeApp;

var data = new GameLogic();
data.SetUpField();

while (true)
{
    Console.Clear();
    Console.SetCursorPosition(0, 0);
    data.GetNextGeneration();
    data.TransferNextGenerations();
    Display.ShowData(data);
    Thread.Sleep(1000);

    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
        break;
}
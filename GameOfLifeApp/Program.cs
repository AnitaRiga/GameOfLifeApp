using GameOfLifeApp;

Console.Title = $"Game Of Life.";

var gameManager = new GameManager(new Communicator(), new Display(), new GameLogic(), new Serializer());

IApplicationManager running = new ApplicationManager(
    new Communicator(),
    new Serializer(),
    gameManager);

running.RunApplication();
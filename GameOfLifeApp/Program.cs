using GameOfLifeApp;

Console.Title = $"Game Of Life.";

var gameManager = new GameManager(new Communicator(), new Display(), new GameLogic(), new Serializer());

IApplicationManager running = new ApplicationManager(gameManager);

running.RunApplication(new GameField(), new Communicator(), new Serializer());
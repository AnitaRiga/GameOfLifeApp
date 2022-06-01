using GameOfLifeApp;

Console.Title = $"Game Of Life.";

var serializer = new Serializer();
var communicator = new Communicator();
var gameManager = new GameManager(communicator, new Display(), new GameLogic(), serializer);

IApplicationManager running = new ApplicationManager();

running.RunApplication(communicator, serializer, gameManager);



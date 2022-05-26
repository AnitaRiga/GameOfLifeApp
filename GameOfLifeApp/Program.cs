using GameOfLifeApp;

Console.Title = $"Game Of Life.";

var field = new GameField(); 

IApplicationManager trigger = new ApplicationManager(
    new Communicator(),    
    new GameLogic(),
    new Serializer(),
    new GameManager(new Communicator(), new Display(field), new GameLogic(), new Serializer()));

trigger.RunApplication();
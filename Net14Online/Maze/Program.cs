using Maze.ConsolePlay;
using Maze.LevelStaff;
using System.Reflection.Metadata.Ecma335;

var builder = new LevelBuilder();
var level = builder.BuildV0(10, 10);

// player push the button
var consoleController = new ConsoleController();
consoleController.Play();

var drawer = new LevelDrawer();
drawer.Draw(level);
using Maze.ConsolePlay;
using Maze.LevelStaff;
using System.Reflection.Metadata.Ecma335;

var builder = new LevelBuilder();
<<<<<<< HEAD
var level = builder.BuildV5();
=======
var level = builder.BuildV0(10, 10);
>>>>>>> main

// player push the button
var consoleController = new ConsoleController();
consoleController.Play();

var drawer = new LevelDrawer();
<<<<<<< HEAD
drawer.Draw(level);
Console.ReadLine();
=======
drawer.Draw(level);
>>>>>>> main


using Maze.LevelStaff;

var builder = new LevelBuilder();
var level = builder.BuildV7(21, 21);

// player push the button

var drawer = new LevelDrawer();
drawer.Draw(level);


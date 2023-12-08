
using Maze.LevelStaff;

var builder = new LevelBuilder();
var level = builder.BuildV0(12, 7);

// player push the button

var drawer = new LevelDrawer();
drawer.Draw(level);


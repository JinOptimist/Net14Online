using Maze.LevelStaff;

var builder = new LevelBuilder();
var level = builder.BuildV11(9, 5);

// player push the button

var drawer = new LevelDrawer();
drawer.Draw(level);

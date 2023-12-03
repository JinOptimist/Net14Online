using Maze.LevelStaff;

var builder = new LevelBuilder();
var level = builder.BuildV11(10, 5);

var drawer = new LevelDrawer();
drawer.Draw(level);

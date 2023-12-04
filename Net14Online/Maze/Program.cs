using Maze.LevelStaff;

var builder = new LevelBuilder();
var level = builder.BuildV8(10, 10, 3);

// player push the button

var drawer = new LevelDrawer();
drawer.Draw(level);

using Maze.LevelStaff;

var builder = new LevelBuilder();
var level = builder.BuildV0(20, 30);

// player push the button

var drawer = new LevelDrawer();
drawer.Draw(level);

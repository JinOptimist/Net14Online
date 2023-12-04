using Maze.LevelStaff;

var builder = new LevelBuilder();
//var level = builder.BuildV0(12, 7);
var level = builder.BuildV0(10, 10);


// player push the button

var drawer = new LevelDrawer();
drawer.Draw(level);

using Maze.LevelStaff;
using System.Threading.Channels;

var builder = new LevelBuilder();
var level = builder.BuildV0(20, 10);

// player push the button

var drawer = new LevelDrawer();
drawer.Draw(level);










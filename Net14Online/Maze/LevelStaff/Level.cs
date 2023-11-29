using Maze.Cells;

namespace Maze.LevelStaff
{
    public class Level
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<BaseCell> Cells { get; set; } = new List<BaseCell>();
    }
}

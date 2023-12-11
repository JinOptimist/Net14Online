using Maze.Cells;
using Maze.Cells.Creatures;

namespace Maze.LevelStaff
{
    public class Level
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<BaseCell> Cells { get; set; } = new List<BaseCell>();
        public Hero Hero { get; set; }
        public void ReplaceCell (BaseCell oldCell, BaseCell newCell)
        {
            Cells.Remove (oldCell);
            Cells.Add (newCell);
        }
    }
}

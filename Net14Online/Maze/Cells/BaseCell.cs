using Maze.Cells.Creatures;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public abstract class BaseCell
    {
        protected BaseCell(int coordinateX, int coordinateY, Level level)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Level = level;
        }

        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public Level Level { get; }

        public abstract string Symbol { get; }

        public abstract bool Step(BaseCreature creature);
    }
}

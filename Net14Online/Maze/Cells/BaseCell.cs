using Maze.Cells.Creatures;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public abstract class BaseCell
    {
        protected BaseCell(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.Gray)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Level = level;
            Color = color;
        }

        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public Level Level { get; }
        public ConsoleColor Color { get; set; }

        public abstract string Symbol { get; }

        public abstract bool Step(BaseCreature creature);
    }
}

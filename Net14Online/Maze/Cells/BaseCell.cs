using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public abstract class BaseCell : IBaseCell
    {
        protected BaseCell(int coordinateX, int coordinateY, ILevel level, ConsoleColor color = ConsoleColor.Gray)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Level = level;
            Color = color;
        }
        
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public ILevel Level { get; }
        public ConsoleColor Color { get; set; }

        public abstract string Symbol { get; }

        public abstract bool Step(IBaseCreature creature);
    }
}

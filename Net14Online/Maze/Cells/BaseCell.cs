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
            LevelDrawer.RedrawCellAction?.Invoke(this);
        }

        private int coordinateX;
        private int coordinateY;

        public int OldCoordinateX { get; private set; }
        public int OldCoordinateY { get; private set; }
        public int CoordinateX
        {
            get { return coordinateX; }
            set
            {
                OldCoordinateX = coordinateX;
                coordinateX = value;
                LevelDrawer.RedrawCellAction?.Invoke(this);
            }
        }
        public int CoordinateY
        {
            get { return coordinateY; }
            set
            {
                OldCoordinateY = coordinateY;
                coordinateY = value;
                LevelDrawer.RedrawCellAction?.Invoke(this);
            }
        }
        public ILevel Level { get; }
        public ConsoleColor Color { get; set; }

        public abstract string Symbol { get; }

        public abstract bool Step(IBaseCreature creature);
    }
}

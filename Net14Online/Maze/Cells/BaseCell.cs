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
            State?.Invoke(this);
        }

        private int coordinateX;
        private int coordinateY;

        public event IBaseCell.StateDelegate State;

        public delegate void StateDelegate(BaseCell newPositionCell);

        public int OldCoordinateX { get; set; }
        public int OldCoordinateY { get; set; }
        public int CoordinateX
        {
            get { return coordinateX; }
            set
            {
                OldCoordinateX = coordinateX;
                coordinateX = value;
                StateUpdate();
            }
        }
        public int CoordinateY
        {
            get { return coordinateY; }
            set
            {
                OldCoordinateY = coordinateY;
                coordinateY = value;
                StateUpdate();
            }
        }
        public ILevel Level { get; }
        public ConsoleColor Color { get; set; }

        public abstract string Symbol { get; }

        public abstract bool Step(IBaseCreature creature);

        public void StateUpdate()
        {
            State?.Invoke(this);
        }
    }
}

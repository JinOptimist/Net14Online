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

        private int _coordinateX;
        private int _coordinateY;
        private ConsoleColor _color;

        public event IBaseCell.StateDelegate State;

        public delegate void StateDelegate(BaseCell newPositionCell);

        public int OldCoordinateX { get; set; }
        public int OldCoordinateY { get; set; }
        public int CoordinateX
        {
            get { return _coordinateX; }
            set
            {
                OldCoordinateX = _coordinateX;
                _coordinateX = value;
                StateUpdate();
            }
        }
        public int CoordinateY
        {
            get { return _coordinateY; }
            set
            {
                OldCoordinateY = _coordinateY;
                _coordinateY = value;
                StateUpdate();
            }
        }
        public ILevel Level { get; }
        public ConsoleColor Color
        {
            get { return _color; }
            set
            {
                _color = value;
                StateUpdate();
            }
        }

        public abstract string Symbol { get; }

        public abstract bool Step(IBaseCreature creature);

        public void StateUpdate()
        {
            State?.Invoke(this);
        }
    }
}

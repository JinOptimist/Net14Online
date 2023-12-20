using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells.CellInterfaces
{
    public interface IBaseCell
    {
        ConsoleColor Color { get; set; }
        public int OldCoordinateX { get; set; }
        public int OldCoordinateY { get; set; }
        int CoordinateX { get; set; }
        int CoordinateY { get; set; }
        ILevel Level { get; }
        string Symbol { get; }

        public delegate void StateDelegate(IBaseCell newPositionCell);
        public event StateDelegate State;

        bool Step(IBaseCreature creature);
        public void StateUpdate();
    }
}
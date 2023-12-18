using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells.CellInterfaces
{
    public interface IBaseCell
    {
        ConsoleColor Color { get; set; }
        int CoordinateX { get; set; }
        int CoordinateY { get; set; }
        ILevel Level { get; }
        string Symbol { get; }

        bool Step(IBaseCreature creature);
    }
}
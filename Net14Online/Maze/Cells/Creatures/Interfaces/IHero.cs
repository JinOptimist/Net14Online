using Maze.Cells.CellInterfaces;

namespace Maze.Cells.Creatures.Interfaces;

public interface IHero : IBaseCreature
{
    IBaseCreature Step();

    IBaseCell ChooseCellToStep();
}
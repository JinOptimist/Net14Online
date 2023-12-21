using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.Helper;
using Maze.LevelStaff;

namespace Maze.Cells.Creatures;

public class GoodMonster : BaseCreature
{
    private Random _random = new Random();
    public GoodMonster(int coordinateX, int coordinateY, ILevel level, ConsoleColor consoleColor = ConsoleColor.Yellow) : base(coordinateX, coordinateY, level,consoleColor)
    {
    }

    public override string Symbol => "m";
    public override bool Step(IBaseCreature creature)
    {
        if (creature is GoodMonster)
        {
            return false;
        }

        creature.Hp++; 
        return false;
    }

    public override IBaseCell ChooseCellToStep()
    {
        var cells = Level.GetNearCells<Ground>(this);
        if (cells.Any())
        {
            return cells.GetRandom();
        }

        //If we hasn't Ground on near cells stay on the same cells
        return Level.Cells.First(x => x.CoordinateX == CoordinateX && x.CoordinateY == CoordinateY);
    }
}
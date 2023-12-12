using Maze.LevelStaff;

namespace Maze.Cells.Creatures;

public class GoodMonster : BaseCreature
{
    private Random _random = new Random();
    public GoodMonster(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
    {
    }

    public override string Symbol => "m";
    public override bool Step(BaseCreature creature)
    {
        if (creature is GoodMonster)
        {
            return false;
        }

        creature.Hp++; 
        return false;
    }

    public override BaseCell ChooseCellToStep()
    {
        var cellsGround = Level.GetNearCells<Ground>(this);
        var randomIndex = _random.Next(cellsGround.Count);
        var cellGround = cellsGround[randomIndex];
        return cellGround;
    }
    
   
}
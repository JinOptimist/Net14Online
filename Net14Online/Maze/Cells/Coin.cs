using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Coin : BaseCell
    {
        public Coin(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "c";

        public override bool Step(IBaseCreature creature)
        {
            creature.Money++;
            return true;
        }
    }
}

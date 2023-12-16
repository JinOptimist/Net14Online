using Maze.Cells.Creatures;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Moon : BaseCell
    {
        public Moon(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => ")";

        public override bool Step(BaseCreature creature)
        {
            creature.Money *= 2;
            var ground = new Ground(CoordinateX, CoordinateY, Level);
            Level.ReplaceCell(this, ground);
            return true;
        }
    }
}

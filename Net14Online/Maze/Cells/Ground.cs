using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Ground : BaseCell
    {
        public Ground(int coordinateX, int coordinateY, ILevel level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => ".";

        public override bool Step(IBaseCreature creature)
        {
            return true;
        }
    }
}

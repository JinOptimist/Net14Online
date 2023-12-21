using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Ground : BaseCell, IGround
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

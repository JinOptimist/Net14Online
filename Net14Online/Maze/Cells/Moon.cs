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
            throw new NotImplementedException();
        }
    }
}

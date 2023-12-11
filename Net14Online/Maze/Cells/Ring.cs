using Maze.Cells.Creatures;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Ring : BaseCell
    {
        public Ring(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "o";

        public override bool Step(BaseCreature creature)
        {
            throw new NotImplementedException();
        }
    }
}

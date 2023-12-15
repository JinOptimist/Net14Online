using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Pit : BaseCell
    {
        public Pit(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "~";

        public override bool Step(IBaseCreature creature)
        {
            throw new NotImplementedException();
        }
    }
}

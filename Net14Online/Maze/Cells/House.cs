using Maze.Cells.Creatures;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class House : BaseCell
    {
        public House(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "^";

        public override bool Step(BaseCreature creature)
        {
            if (creature is Hero)
            {
                creature.Hp *= 2;
            }
            return true;
        }
    }
}

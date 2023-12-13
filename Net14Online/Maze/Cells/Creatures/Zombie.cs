using Maze.LevelStaff;

namespace Maze.Cells.Creatures
{
    public class Zombie : BaseCreature
    {
        public override string Symbol => "Z";

        public Zombie(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {

        }

        public override BaseCell ChooseCellToStep()
        {
            throw new NotImplementedException();
        }

        public override bool Step(BaseCreature creature)
        {
            throw new NotImplementedException();
        }
    }
}

using Maze.LevelStaff;
using System.Reflection.Metadata.Ecma335;

namespace Maze.Cells.Creatures
{
    public class Hero : BaseCreature
    {
        public override string Symbol => "H";

        public Hero(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override bool Step(BaseCreature creature)
        {
            throw new NotImplementedException();
        }
    }
}

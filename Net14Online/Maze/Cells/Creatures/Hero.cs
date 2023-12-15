using Maze.LevelStaff;

namespace Maze.Cells.Creatures
{
    public class Hero : BaseCreature
    {
        public override string Symbol => "H";

        public Hero(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.DarkYellow) : base(coordinateX, coordinateY, level, color)
        {
        }

        public override bool Step(BaseCreature creature)
        {
            throw new NotImplementedException();
        }

        public override BaseCell ChooseCellToStep()
        {
            throw new NotImplementedException();
        }
    }
}

using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells.Creatures
{
    public class Hero : BaseCreature, IHero
    {
        public const int MAX_HERO_STRESS = 100;
        public const int MIN_HERO_STRESS = 0;
        public override string Symbol => "H";

        public Hero(int coordinateX, int coordinateY, ILevel level, ConsoleColor color = ConsoleColor.DarkYellow) : base(coordinateX, coordinateY, level, color)
        {
        }


        public override bool Step(IBaseCreature creature)
        {
            throw new NotImplementedException();
        }

        public override IBaseCell ChooseCellToStep()
        {
            throw new NotImplementedException();
        }
    }
}

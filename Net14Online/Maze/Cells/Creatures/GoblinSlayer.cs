using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.Helper;
using Maze.LevelStaff;
using System.Linq.Expressions;

namespace Maze.Cells.Creatures
{
    public class GoblinSlayer : BaseCreature
    {
        public const ConsoleColor DEFAULT_COLOR = ConsoleColor.Magenta;

        public GoblinSlayer(int coordinateX, int coordinateY, ILevel level) 
            : base(coordinateX, coordinateY, level, DEFAULT_COLOR)
        {
        }

        public override string Symbol => "F";

        public override IBaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<Ground>(this);
            return cells.GetRandom();
        }

        public override bool Step(IBaseCreature creature)
        {
            switch (creature)
            {
                case GoblinStupid:
                    creature.Hp-=2;
                    break;
                case Hero:
                    creature.Money--;
                    break;
                default:
                    creature.Hp--;
                    break;
            }

            return false;
        }
    }
}

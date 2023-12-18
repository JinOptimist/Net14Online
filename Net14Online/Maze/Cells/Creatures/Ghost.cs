using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells.Creatures
{

    public class Ghost : BaseCreature
    {
        private Random _random = new Random();
        public Ghost(int coordinateX, int coordinateY, ILevel level, ConsoleColor color = ConsoleColor.White) : base(coordinateX, coordinateY, level, color, true)
        {
        }

        public override string Symbol => "B"; //Symbol "B" = [B]ooo

        public override IBaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<BaseCell>(this);
            var randomIndex = _random.Next(cells.Count);
            var cell = cells[randomIndex];
            return cell;
        }

        public override bool Step(IBaseCreature creature)
        {
            var hero = creature as IHero;

            if (hero is null)
            {
                return false;
            }

            hero.Hp -= 1;

            return false;
        }
    }
}

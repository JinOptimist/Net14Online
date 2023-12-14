using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells.Creatures
{
    public class Snake : BaseCreature
    {
        private Random _random = new Random();
        public Snake(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.DarkBlue) : base(coordinateX, coordinateY, level,color)
        {
        }

        public override string Symbol => "s";

        public override BaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<BaseCell>(this);
            var randomInex = _random.Next(cells.Count);
            var cell = cells[randomInex];
            return cell;
        }

        public override bool Step(BaseCreature creature)
        {
            if (creature is Snake)
            {
                return false;
            }

            creature.Hp--;
            return false;
        }
    }
}

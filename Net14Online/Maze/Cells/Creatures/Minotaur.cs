using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells.Creatures
{
    public class Minotaur : BaseCreature
    {
        private Random _random = new Random();
        public Minotaur(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "M";

        public override BaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<BaseCell>(this);
            var randomInex = _random.Next(cells.Count);
            var cell = cells[randomInex];
            return cell;
        }
        public override bool Step(BaseCreature creature)
        {
            if (creature is Minotaur)
            {
                return false;
            }

            creature.Hp -= 2;
            return false;
        }
    }
}

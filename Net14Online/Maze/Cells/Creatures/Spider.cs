using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.Helper;
using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells.Creatures
{
    public class Spider : BaseCreature
    {
        public override string Symbol => "M";
        public Spider(int CoordinateX, int CoordinateY, ILevel Level, ConsoleColor color = ConsoleColor.Red) : base(CoordinateX, CoordinateY, Level, color)
        { }
        public override IBaseCell ChooseCellToStep()
        {
            var _random = new Random();
            var cells = Level.Cells.Where(x => x is not Wall).ToList();
            var randomIndex = _random.Next(cells.Count);
            var cell = cells[randomIndex];

            return cell;
        }
        public override bool Step(IBaseCreature creature)
        {
            if (creature is Spider)
            {
                return false;
            }

            if (creature.Hp > 2)
            {
                creature.Hp -= 2;
            }
            else if (creature.Hp == 1)
            {
                creature.Hp--;
            }

            return false;
        }
    }
}
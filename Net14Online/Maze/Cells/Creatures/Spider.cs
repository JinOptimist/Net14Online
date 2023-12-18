using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
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
    
        public Spider(int coordinateX, int coordinateY, ILevel level, ConsoleColor color = ConsoleColor.Red) : base(coordinateX, coordinateY, level, color)
        { }
        public override IBaseCell ChooseCellToStep()
        {
            var _random = new Random();
            var cells = Level.Cells.Where(x => x is not Wall).ToList();
            var randomInex = _random.Next(cells.Count);
            var cell = cells[randomInex];
            return cell;
        }
        public override bool Step(IBaseCreature creature)
        {
            if (creature is Spider)
            {
                return false;
            }

            if (creature.Hp > 0)
            {
                creature.Hp-=2;
            }

            return false;
        }
    }
}

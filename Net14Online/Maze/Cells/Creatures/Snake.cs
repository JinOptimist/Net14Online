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
    public class Snake : BaseCreature
    {
        private Random _random = new Random();
        public Snake(int coordinateX, int coordinateY, ILevel level, ConsoleColor color = ConsoleColor.DarkBlue) : base(coordinateX, coordinateY, level,color)
        {
        }

        public override string Symbol => "s";

        public override IBaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<IBaseCell>(this);
            var randomInex = _random.Next(cells.Count);
            var cell = cells[randomInex];
            return cell;
        }

        public override bool Step(IBaseCreature creature)
        {
            if (creature is Snake)
            {
                return false;
            }

            if (creature.Hp > 0)
            {
                creature.Hp--;
            }

            return false;
        }     
    }
}

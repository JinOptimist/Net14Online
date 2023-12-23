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
    public class Witch : BaseCreature
    {
        private Random _random = new Random();
        public Witch(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.DarkCyan)
            : base(coordinateX, coordinateY, level, color)
        {
        }

        public override string Symbol => "W";

        public override IBaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<BaseCell>(this);
            var randomInex = _random.Next(cells.Count);
            var cell = cells[randomInex];
            return cell;
        }

        public override bool Step(IBaseCreature creature)
        {

            var hero = creature as Hero;
            if (hero is not null)
            {
                creature.Hp -= 2;
                return true;
            }

            return false;
        }
    }
}
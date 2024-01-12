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

    public class Thief : BaseCreature
    {
        private int _robMoney = 10;

        private Random _random = new Random();

        public Thief(int coordinateX, int coordinateY, ILevel level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "t";

        public override IBaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<IBaseCell>(this);
            var randomInex = _random.Next(cells.Count);
            var cell = cells[randomInex];
            return cell;
        }

        public override bool Step(IBaseCreature creature)
        {
            if (creature is Hero)
            {
                if (creature.Money > _robMoney)
                {
                    creature.Money -= 10;
                }
                else
                {
                    creature.Money = 0;
                }
            }
            return true;
        }
    }
}

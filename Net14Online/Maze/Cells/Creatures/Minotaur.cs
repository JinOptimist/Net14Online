using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells.Creatures
{
    public class Minotaur : BaseCreature
    {
        private Random _random = new Random();
        public Minotaur(int coordinateX, int coordinateY, ILevel level, ConsoleColor color) : base(coordinateX, coordinateY, level, color)
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
        public override bool Step(IBaseCreature creature)
        {
            if (creature is Minotaur)
            {
                return false;
            }
            var hero = creature as IHero;
            if (hero is null)
            {
                return false;
            }

            hero.Hp = hero.Hp < 1 ? 0 : hero.Hp - 1;
            hero.Money = hero.Money < 1 ? 0 : hero.Money - 2;

            return false;
        }
    }
}

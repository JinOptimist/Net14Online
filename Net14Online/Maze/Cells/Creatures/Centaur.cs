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
    public class Centaur : BaseCreature
    {
        public override string Symbol => "C";

        private  Random _random = new Random();

        public Centaur(int coordinateX, int coordinateY, ILevel level, ConsoleColor color = ConsoleColor.Red) : base(coordinateX, coordinateY, level, color)
        {
        }

        public override IBaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<IGround>(this);
            var random = _random.Next(cells.Count);

            return cells[random];
        }

        public override bool Step(IBaseCreature creature)
        {
            var hero = creature as IHero;
            if (hero is null)
            {
                return false;
            }

            hero.Hp = hero.Hp < 2 ? 0 : hero.Hp - 2;
            hero.Money = hero.Money < 1 ? 0 : hero.Money - 1;

            return false;
        }
    }
}

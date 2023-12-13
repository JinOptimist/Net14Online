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

        public Centaur(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public Centaur(int coordinateX, int coordinateY, Level level, ConsoleColor color) : base(coordinateX, coordinateY, level, color)
        {
        }

        public override BaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<Ground>(this);
            var random = _random.Next(cells.Count);

            return cells[random];
        }

        public override bool Step(BaseCreature creature)
        {
            if(creature is not Hero)
            {
                return false;
            }

            creature.Hp = creature.Hp < 2 ? 0 : creature.Hp - 2;
            creature.Money = creature.Money < 1 ? 0 : creature.Money - 1;

            return false;
        }
    }
}

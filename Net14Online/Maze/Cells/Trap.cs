using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells
{
    internal class Trap : BaseCell
    {
        public const ConsoleColor DEFAULT_COLOR = ConsoleColor.DarkCyan;
        public Trap(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level, DEFAULT_COLOR)
        {
        }
        public override string Symbol => "^";

        public override bool Step(IBaseCreature creature)
        {
            creature.Hp -= 1;

            return true;
        }
    }
}

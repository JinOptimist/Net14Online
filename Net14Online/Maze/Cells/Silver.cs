using Maze.Cells.Creatures;
using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells
{
    internal class Silver : BaseCell
    {
        public Silver(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.Gray) : base(coordinateX, coordinateY, level, color)
        {
        }

        public override string Symbol => "+";

        public override bool Step(BaseCreature creature)
        {
            return true;
        }
    }
}

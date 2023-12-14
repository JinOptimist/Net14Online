using Maze.Cells.Creatures;
using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells
{

    public class Puddle : BaseCell
    {
        public Puddle(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.DarkBlue) : base(coordinateX, coordinateY, level, color)
        {
        }

        public override string Symbol => "O";

        public override bool Step(BaseCreature creature)
        {
            return false;
        }
    }
}

using Maze.Cells.Creatures;
using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells
{
    internal class Sun : BaseCell
    {
        public Sun(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "*";

        public override bool Step(BaseCreature creature)
        {
            creature.Money += 5;
            return true;
        }
    }
}

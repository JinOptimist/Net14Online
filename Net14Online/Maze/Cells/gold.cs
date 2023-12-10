using Maze.Cells.Creatures;
using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells
{
     public  class Gold : BaseCell
    {
        private Gold goldx;
        private Gold goldy;
        private Level level;
        public Gold(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {

        }
        public override string Symbol => "+";
        public override bool Step(BaseCreature creature)
        {
            return true;
        }
    }
}

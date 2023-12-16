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
     public  class Gold : BaseCell
    {
        public Gold(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {

        }








        public override string Symbol => "+";
        public override bool Step(IBaseCreature creature)
        {
            return true;
        }
    }
}

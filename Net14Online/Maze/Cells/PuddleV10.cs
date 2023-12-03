using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells
{
    public class PuddleV10 : BaseCell
    {
       
        public PuddleV10(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
            
        }
        public override string Symbol => "O";
    }
}

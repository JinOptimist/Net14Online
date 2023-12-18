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
    internal class Sun : BaseCell
    {
        public Sun(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.Yellow) : base(coordinateX, coordinateY, level, color)
        {
        }

        public override string Symbol => "*";

        public override bool Step(IBaseCreature creature)
        {
            creature.Money += 5;
            return true;
        }
    }
}

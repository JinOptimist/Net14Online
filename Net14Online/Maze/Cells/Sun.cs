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
            if (creature is Hero)
            {
                creature.Money += 5;
                var ground = new Ground(CoordinateX, CoordinateY, Level);
                Level.ReplaceCell(this, ground);
            }
            return true;
        }
    }
}

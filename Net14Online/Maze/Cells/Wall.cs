using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using System.ComponentModel.Design;

namespace Maze.Cells
{
    public class Wall : BaseCell
    {
        public Wall(int coordinateX, int coordinateY, Level level, bool stepInWall = false) : base(coordinateX, coordinateY, level)
        {
        }

        private bool stepInWall;

        public override string Symbol => "#";

        public override bool Step(IBaseCreature creature)
        {
            if (this.stepInWall)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

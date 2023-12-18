using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Cage : BaseCell
    {
        private bool isFirstStep = true;
        public Cage(int coordinateX, int coordinateY, ILevel level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "&";

        public override bool Step(IBaseCreature creature)
        {
            if (isFirstStep)
            {
                isFirstStep = false;
                return false;
            }

            isFirstStep = true;
            return true;
        }
    }
}


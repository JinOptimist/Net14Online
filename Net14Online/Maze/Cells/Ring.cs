using Maze.Cells.Creatures;
using Maze.LevelStaff;
using System;

namespace Maze.Cells
{
    public class Ring : BaseCell
    {
        private int moneyCount;
        private bool isUsed;

        public Ring(int coordinateX, int coordinateY, Level level, int moneyCount) : base(coordinateX, coordinateY, level)
        {
            this.moneyCount = moneyCount;
            isUsed = false;
        }

        public override string Symbol => isUsed ? " " : "o";

        public override bool Step(BaseCreature creature)
        {
            if (creature is Hero && !isUsed)
            {
                
                ((Hero)creature).Money += 5;
                ((Hero)creature).Hp += 5;
                ((Hero)creature).Age += 5;

                isUsed = true;
            }
            return true;
        }
    }
}

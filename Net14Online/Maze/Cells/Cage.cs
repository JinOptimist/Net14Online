﻿using Maze.Cells.Creatures;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Cage : BaseCell
    {
        private bool isFirstStep = true;
        public Cage(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "&";

        public override bool Step(BaseCreature creature)
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


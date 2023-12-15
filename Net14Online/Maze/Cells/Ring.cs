using Maze.Cells.Creatures;
using Maze.LevelStaff;
using System;

namespace Maze.Cells
{
    public class Ring : BaseCell
    {
        private bool _isUsed;

        public Ring(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
            _isUsed = false;
        }

        public override string Symbol => _isUsed ? " " : "o";

        public override bool Step(BaseCreature creature)
        {
            if (!_isUsed)
            {
                creature.Money += 5;
                creature.Hp += 5;
                creature.Age += 5;

               _isUsed = true;
            }
            return true;
        }
    }
}

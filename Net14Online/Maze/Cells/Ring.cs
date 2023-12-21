using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using System;

namespace Maze.Cells
{
    public class Ring : BaseCell
    {
        private bool _isUsed;

        public Ring(int coordinateX, int coordinateY, ILevel level) : base(coordinateX, coordinateY, level)
        {
            _isUsed = false;
        }

        public override string Symbol => _isUsed ? " " : "o";

        public override bool Step(IBaseCreature creature)
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

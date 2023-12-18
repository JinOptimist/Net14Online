using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using System;

namespace Maze.Cells
{
    public class Ring : BaseCell
    {
        private int BonusAmount { get; set; }
        private bool _isUsed;
      
        public Ring(int coordinateX, int coordinateY, ILevel level, int BonusAmount) : base(coordinateX, coordinateY, level)
        {
            _isUsed = false;
            this.BonusAmount = BonusAmount;
        }

        public override string Symbol => _isUsed ? " " : "o";

        public override bool Step(IBaseCreature creature)
        {
            if (creature is IHero && !_isUsed)
            {
                creature.Money += BonusAmount;
                creature.Hp += BonusAmount;
                creature.Age += BonusAmount;

                _isUsed = true;
                
            }
            return true;
        }
    }
}



using Maze.LevelStaff;
using System;

namespace Maze.Cells.Creatures
{
    public class Ghost : BaseCreature
    {
        private Random _random = new Random();
        public Ghost(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "B"; //Symbol "B" = [B]ooo

        public override BaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<Ground>(this); //TODO переделать на любые ячейки и найти способ обойти step=false у ячеек
            var randomIndex = _random.Next(cells.Count);
            var cell = cells[randomIndex];
            return cell;
        }

        public override bool Step(BaseCreature creature)
        {
            return true;
        }
    }
}

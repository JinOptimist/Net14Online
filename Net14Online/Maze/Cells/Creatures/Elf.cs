using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using System;
namespace Maze.Cells.Creatures
{
    public class Elf : BaseCreature
    {
        private Random _random = new Random();
        public Elf(int coordinateX, int coordinateY, ILevel level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "E";

        public override BaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<BaseCell>(this);
            var randomInex = _random.Next(cells.Count);
            var cell = cells[randomInex];
            return cell;
        }

        public override bool Step(IBaseCreature creature)
        {
            if (creature is Elf)
            {
                return false;
            }

            creature.Hp++;
            return false;
        }
    }
}


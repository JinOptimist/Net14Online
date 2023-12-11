using Maze.Cells.Creatures;
using Maze.LevelStaff;

namespace Maze.Cells
{
    internal class Chest : BaseCell
    {
        public Chest(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "4"; //Symbol 4 = [Ch]est

        public override bool Step(BaseCreature creature)
        {
            var rnd = new Random(100);
            var MimicOrNot = rnd.Next(0, 100);

            if (MimicOrNot < 20)
            {
                creature.Hp -= 2;
            }
            else
            {
                creature.Money += 10;
            }
            var ground = new Ground(CoordinateX, CoordinateY, Level);
            Level.ReplaceCell(this, ground);
            return true;
        }

        }
    }
}

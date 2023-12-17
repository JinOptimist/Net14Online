using Maze.Cells.Creatures;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Chest : BaseCell
    {
        public Chest(int coordinateX, int coordinateY, Level level, bool mimicOrNot) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "4"; //Symbol 4 = [Ch]est

        public bool mimicorNot { get; private set; }

        public override bool Step(BaseCreature creature)
        {
            if (mimicorNot)
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
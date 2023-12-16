using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells
{
    internal class Chest : BaseCell
    {
        public Chest(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "4"; //Symbol 4 = [Ch]est

        public override bool Step(IBaseCreature creature)
        {
            return false;
        }
    }
}
using Maze.Cells.Creatures;
using Maze.LevelStaff;

namespace Maze.Cells
{
    internal class Diamond: BaseCell 
    {
        public Diamond(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "=";

        public override bool Step(BaseCreature creature)
        {
            creature.Money += 10;
            var ground = new Ground(CoordinateX, CoordinateY, Level);
            Level.ReplaceCell(this,ground);
            return true;
        }
    }
}

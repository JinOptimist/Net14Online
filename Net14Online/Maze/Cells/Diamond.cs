using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using System.Drawing;

namespace Maze.Cells
{
    internal class Diamond: BaseCell 
    {
        public Diamond(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.Blue) : base(coordinateX, coordinateY, level)
        {
        }
        public override string Symbol => "=";

        public override bool Step(IBaseCreature creature)
        {
            creature.Money += 10;
            var ground = new Ground(CoordinateX, CoordinateY, Level);
            Level.ReplaceCell(this,ground);
            return true;
        }
    }
}

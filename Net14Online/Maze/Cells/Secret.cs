using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells
{
    internal class Secret : BaseCell
    {
        private BaseCell[] cellsForSecret;

        public Secret(int coordinateX, int coordinateY, Level level, BaseCell[] cellsForSecret) : base(coordinateX, coordinateY, level)
        {
            this.cellsForSecret = cellsForSecret;
        }

        public Secret(int coordinateX, int coordinateY, Level level, ConsoleColor color, BaseCell[] cellsForSecret) : base(coordinateX, coordinateY, level, color)
        {
            this.cellsForSecret = cellsForSecret;
        }

        public override string Symbol => "?";

        public override bool Step(IBaseCreature creature)
        {
            if (cellsForSecret.Length == 0)
                return true;
            Random rnd = new Random();
            cellsForSecret[rnd.Next(0, cellsForSecret.Length)].Step(creature);
            return true;
        }
    }
}
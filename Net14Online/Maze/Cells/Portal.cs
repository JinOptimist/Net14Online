using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Portal : BaseCell
    {
        public Portal(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "@";
    }
}

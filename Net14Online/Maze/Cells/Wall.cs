using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Wall : BaseCell
    {
        public Wall(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "#";
    }
}

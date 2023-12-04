using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Ground : BaseCell
    {
        public Ground(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "░";
    }
}

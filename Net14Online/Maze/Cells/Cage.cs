using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Cage : BaseCell
    {
        public Cage(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "&";
    }
}


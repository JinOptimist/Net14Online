using Maze.LevelStaff;

namespace Maze.Cells
{
    
    public class Exclamation : BaseCell
    {
        public Exclamation(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

       
        public override string Symbol => "!";
    }
}

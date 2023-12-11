using Maze.LevelStaff;

namespace Maze.Cells.Creatures
{
    public abstract class BaseCreature : BaseCell
    {
        public int Money { get; set; } = 0;
        public int Hp { get; set; } = 1;
        public int Age { get; set; } = 10;

        public BaseCreature(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }
    }
}

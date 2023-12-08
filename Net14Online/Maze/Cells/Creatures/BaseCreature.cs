using Maze.LevelStaff;

namespace Maze.Cells.Creatures
{
    public abstract class BaseCreature : BaseCell
    {
        public int Money { get; set; } = 0;
        public int Hp { get; set; } = 1;

        public BaseCreature(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public BaseCreature(int coordinateX, int coordinateY, Level level, ConsoleColor color) : base(coordinateX, coordinateY, level, color)
        {
        }
    }
}

using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells.Creatures
{
    public abstract class BaseCreature : BaseCell, IBaseCreature
    {
        public int Money { get; set; } = 0;
        public int Hp { get; set; } = 1;
        public int Age { get; set; } = 10;
        
        public int Stress { get; set; } = 0;
        public BaseCreature(int coordinateX, int coordinateY, ILevel level, ConsoleColor color = ConsoleColor.Gray, bool stepInWall = false) : base(coordinateX, coordinateY, level, color)
        {
        }

        public abstract IBaseCell ChooseCellToStep();
    }
}

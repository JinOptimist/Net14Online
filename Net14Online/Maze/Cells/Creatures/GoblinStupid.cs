using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.Helper;
using Maze.LevelStaff;

namespace Maze.Cells.Creatures
{
    public class GoblinStupid : BaseCreature
    {
        private Random _random = new Random();
        
        public const ConsoleColor DEFAULT_COLOR = ConsoleColor.DarkGreen;

        public GoblinStupid(int coordinateX, int coordinateY, ILevel level) 
            : base(coordinateX, coordinateY, level, DEFAULT_COLOR)
        {
        }

        public override string Symbol => "g";

        public override IBaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<IBaseCell>(this);
            return cells.GetRandom();
        }

        public override bool Step(IBaseCreature creature)
        {
            if (creature is GoblinStupid)
            {
                return false;
            }

            if (creature.Hp > 0)
            {
                creature.Hp--;
            }
            
            return false;
        }
    }
}

using Maze.LevelStaff;

namespace Maze.Cells.Creatures
{
    public class GoblinStupid : BaseCreature
    {
        private Random _random = new Random();
        
        public GoblinStupid(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.DarkGreen) : base(coordinateX, coordinateY, level, color)
        {
        }

        public override string Symbol => "g";

        public override BaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<BaseCell>(this);
            var randomInex = _random.Next(cells.Count);
            var cell = cells[randomInex];
            return cell;
        }

        public override bool Step(BaseCreature creature)
        {
            if (creature is GoblinStupid)
            {
                return false;
            }

            creature.Hp--;
            return false;
        }
    }
}

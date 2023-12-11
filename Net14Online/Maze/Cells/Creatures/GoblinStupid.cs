using Maze.LevelStaff;

namespace Maze.Cells.Creatures
{
    public class GoblinStupid : BaseCreature
    {
        private Random _random = new Random();
        public GoblinStupid(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
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
            creature.Hp--;
            return false;
        }
    }
}

using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Pit : BaseCell
    {
        private Random _random = new Random();

        public Pit(int coordinateX, int coordinateY, ILevel level) : base(coordinateX, coordinateY, level)
        {

        }

        public override string Symbol => "~";

        public override bool Step(IBaseCreature creature)
        {
            var pits = Level.Cells.Where(x => x is Pit).ToList();
            if (pits.Count > 1)
            {
                var randomPitNumber = _random.Next(pits.Count);
                var randomPit = pits[randomPitNumber];

                if (CheckPosition(creature, randomPit) && randomPitNumber < pits.Count)
                {
                    randomPit = pits[randomPitNumber + 1];
                }
                if (CheckPosition(creature, randomPit) && randomPitNumber == pits.Count)
                {
                    randomPit = pits[randomPitNumber - 1];
                }

                creature.CoordinateX = randomPit.CoordinateX;
                creature.CoordinateY = randomPit.CoordinateY;
            }

            return true;
        }

        private bool CheckPosition(IBaseCreature creature, IBaseCell pit)
        {
            var result = false;

            if (pit.CoordinateX != creature.CoordinateX && pit.CoordinateY != creature.CoordinateY)
            {
                result = true;
            }
            return result;
        }
    }
}

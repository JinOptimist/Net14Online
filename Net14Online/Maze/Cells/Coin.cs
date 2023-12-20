using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Coin : BaseCell
    {
        // Поменял входной параметр для консткрутора с Level на интерфейс
        public Coin(int coordinateX, int coordinateY, ILevel level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "c";

        public override bool Step(IBaseCreature creature)
        {
            creature.Money++;
            return true;
        }
    }
}

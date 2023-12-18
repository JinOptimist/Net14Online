using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class Chest : BaseCell
    {
        public Chest(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.Gray, bool mimicOrNot = false)
            : base(coordinateX, coordinateY, level, color)
        {
        }

        public override string Symbol => "4"; //Symbol 4 = [Ch]est


        public bool mimicorNot { get; private set; }

        public override bool Step(IBaseCreature creature)

        {
            var hero = creature as Hero;

            if (hero is null)
            {
                return false;
            }

            if (mimicorNot)
            {
                hero.Hp -= 2;
            }
            else
            {
                hero.Money += 10;
            }
            var ground = new Ground(CoordinateX, CoordinateY, Level);
            Level.ReplaceCell(this, ground);
            return true;
        }
    }
}
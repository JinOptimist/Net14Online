using Maze.Cells.Creatures;
using Maze.LevelStaff;

namespace Maze.Cells
{
    public class House : BaseCell
    {
        public House(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
        {
        }

        public override string Symbol => "^";

        public static void ChangeGroundToHouse(Level level)
        {
            for (int i = 0; i < level.Cells.Count; i = i + 4)
            {
                if (level.Cells[i] is Ground)
                {
                    var randomGround = level.Cells.First(x => x.CoordinateX == level.Cells[i].CoordinateX && x.CoordinateY == level.Cells[i].CoordinateY);
                    House house = new House(level.Cells[i].CoordinateX, level.Cells[i].CoordinateY, level);

                    level.Cells.Remove(randomGround);
                    level.Cells.Add(house);
                }
            }
        }

        public override bool Step(BaseCreature creature)
        {
            if (creature is Hero)
            {
                creature.Hp *= 2;
            }
            return true;
        }
    }
}

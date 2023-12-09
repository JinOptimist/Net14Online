using Maze.Cells.Creatures;
using Maze.LevelStaff;
using System.Reflection.Emit;

namespace Maze.Cells
{
    public class House : BaseCell
    {
        /// <summary>
        /// Property for indicating objects of class House by Color
        /// </summary>
        public static ConsoleColor HouseColor { get; } = ConsoleColor.White;
        /// <summary>
        /// Property for indicating objects of class BaseCell by Color. It depends on landscape of current map and should get value from closed cells.
        /// </summary>
        public ConsoleColor CellColor { get; set; }

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
            creature.Hp *= 2;
            return true;
        }

        public static void SetHouseColor(BaseCell cell, ConsoleColor consoleColor)
        {
            if (cell is House)
            {
                Console.SetCursorPosition(cell.CoordinateX, cell.CoordinateY);
                Console.ForegroundColor = HouseColor;
                Console.BackgroundColor = consoleColor;
            }
        }
        /// <summary>
        /// Just in case when somebody needs to check object color of class House and may be use it
        /// </summary>
        /// <returns></returns>
        public ConsoleColor GetCurrentObjectColor()
        {
            return HouseColor;
        }
        /// <summary>
        /// Just in case when somebody needs to check cell color of class House and may be use or change it
        /// </summary>
        /// <returns></returns>
        public ConsoleColor GetCurrentCellColor()
        {
            return CellColor;
        }
    }
}

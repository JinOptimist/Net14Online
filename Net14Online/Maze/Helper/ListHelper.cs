using Maze.Cells;
using Maze.LevelStaff;

namespace Maze.Helper
{
    public static class ListHelper
    {
        private static Random _random = new Random();
       
        public static T GetRandom<T>(this List<T> list)
        {
            var randomInex = _random.Next(list.Count);
            return list[randomInex];
        }

        public static BaseCell GetRandomCell(this Level level)
        {
            return level.GetRandomCell<BaseCell>();
        }

        public static T GetRandomCell<T>(this Level level)
        {
            var cellsOfType = level.Cells.OfType<T>().ToList();
            var randomIndex = _random.Next(cellsOfType.Count);
            return cellsOfType[randomIndex];
        }
    }
}

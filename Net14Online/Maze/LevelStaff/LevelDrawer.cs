using Maze.Cells.Creatures;

namespace Maze.LevelStaff
{
    public class LevelDrawer
    {
        public void Draw(Level level)
        {
            foreach (var cell in level.Cells)
            {
                Console.SetCursorPosition(cell.CoordinateX, cell.CoordinateY);
                Console.Write(cell.Symbol);
            }
            
            ShowStats(level);

            Console.SetCursorPosition(level.Hero.CoordinateX, level.Hero.CoordinateY);
            Console.Write(level.Hero.Symbol);

            //Console.ReadLine();
        }

        private void ShowStats(Level level)
        {
            Console.SetCursorPosition(level.Width = 0, level.Height +1);
            Console.WriteLine($"HP level.Hero.Name: {level.Hero.Hp}");
            Console.WriteLine($"Money level.Hero.Name: {level.Hero.Money}");
        }
    }
}

namespace Maze.LevelStaff
{
    public class LevelDrawer
    {
        public void Draw(Level level)
        {
            foreach (var cell in level.Cells)
            {
                Console.SetCursorPosition(cell.CoordinateX, cell.CoordinateY);
                Console.ForegroundColor = cell.Color;
                Console.Write(cell.Symbol);
            }

            Console.SetCursorPosition(level.Hero.CoordinateX, level.Hero.CoordinateY);
            Console.ForegroundColor = level.Hero.Color;
            Console.Write(level.Hero.Symbol);
            Console.ResetColor();

            //Console.ReadLine();
        }
    }
}

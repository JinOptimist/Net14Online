namespace Maze.LevelStaff
{
    public class LevelDrawer
    {
        public void Draw(Level level)
        {
            foreach (var cell in level.Cells)
            {
                Console.SetCursorPosition(cell.CoordinateX, cell.CoordinateY);
                cell.DrawAlexandrGlazko();
            }

            Console.SetCursorPosition(level.Hero.CoordinateX, level.Hero.CoordinateY);
            Console.Write(level.Hero.Symbol);

            //Console.ReadLine();
        }
    }
}

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

            Console.SetCursorPosition(level.Hero.CoordinateX, level.Hero.CoordinateY);
            Console.Write(level.Hero.Symbol);

            DrawStatsAlexandrGlazko(level);
            //Console.ReadLine();
        }

        private void DrawStatsAlexandrGlazko(Level level)
        {
            int starterPosY = level.Height + 2;
            Console.SetCursorPosition(0, starterPosY);

            Console.Write($"Hp is: ");
            DrawHpAlexandrGlazko(level);
            Console.WriteLine($"Money is: {level.Hero.Money}");
        }

        private void DrawHpAlexandrGlazko(Level level, char hpSymbol = '♥')
        {
            for(var i = 0; i < level.Hero.Hp; i++)
            {
                Console.Write(hpSymbol);
            }
            Console.WriteLine();
        }
    }
}

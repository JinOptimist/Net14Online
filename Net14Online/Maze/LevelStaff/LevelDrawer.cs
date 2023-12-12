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
            DrawerStatisticsHero(level);

            //Console.ReadLine();
        }
        
        private void DrawerStatisticsHero(Level level)
        {
            Console.SetCursorPosition(0,level.Height);
        
            Console.WriteLine($"HP Hero:{level.Hero.Hp}");
            Console.WriteLine($"Money Hero:{level.Hero.Money}");
       
            Console.SetCursorPosition(level.Hero.CoordinateX,level.Hero.CoordinateY);
            Console.Write(level.Hero.Symbol);
        }
    }
}

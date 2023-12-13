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

            if (level.Hero != null)
            {
                Console.SetCursorPosition(level.Hero.CoordinateX, level.Hero.CoordinateY);
                Console.ForegroundColor = level.Hero.Color;
                Console.Write(level.Hero.Symbol);
            }



            Console.SetCursorPosition(level.Width, level.Height + 1);
            Console.WriteLine();
            Console.WriteLine($"Hero has {level.Hero.Money} dollars");
            Console.WriteLine($"Hero has {level.Hero.Hp} head points");
            Console.WriteLine($"Hero has {level.Hero.Age} years");


            //Console.ReadLine();
        }
    }
}

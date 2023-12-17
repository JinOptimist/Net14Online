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

            foreach (var creature in level.Creatures)
            {
                Console.SetCursorPosition(creature.CoordinateX, creature.CoordinateY);
                Console.Write(creature.Symbol);
            }

            if (level.Hero != null)
            {
                Console.SetCursorPosition(level.Hero.CoordinateX, level.Hero.CoordinateY);
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

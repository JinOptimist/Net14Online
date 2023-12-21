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
                DrawingColorCells(cell.Color);
                Console.Write(cell.Symbol);
            }

            foreach (var creature in level.Creatures)
            {
                Console.SetCursorPosition(creature.CoordinateX, creature.CoordinateY);
                DrawingColorCells(creature.Color);
                Console.Write(creature.Symbol);
            }

            if (level.Hero != null)
            {
                Console.SetCursorPosition(level.Hero.CoordinateX, level.Hero.CoordinateY);
                DrawingColorCells(level.Hero.Color);
                Console.Write(level.Hero.Symbol);
            }


            //Console.ReadLine();
        }

        private void DrawingColorCells(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        
    }
}

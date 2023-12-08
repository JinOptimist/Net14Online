using System.Drawing;

namespace Maze.LevelStaff
{
    public class LevelDrawer
    {
        public void Draw(Level level)
        {
            foreach (var cell in level.Cells)
            {
                Console.SetCursorPosition(cell.CoordinateX, cell.CoordinateY);
                ColorDetectionBySymbol(cell);
                Console.Write(cell.Symbol);
            }

            Console.ReadLine();
        }

        public void ColorDetectionBySymbol(Cells.BaseCell cell)
        {

            switch (cell.Symbol)
            {
                case "O":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;

                default:
                    Console.ResetColor();
                    break;
            }
        

        

            
        }
    }
}

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
        /// <summary>
        /// Вы можете указать символ и цвет, который будет закреплен за этим символом
        /// Примечание: при использовании этого метода не нужно изменять саму структуру ячеек
        /// </summary>
        /// <param name="cell"></param>
        public void ColorDetectionBySymbol(Cells.BaseCell cell)
        {

            switch (cell.Symbol)
            {
                case "O":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "#":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case ".":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
               
                default:
                    Console.ResetColor();
                    break;
            }
        

        

            
        }
    }
}

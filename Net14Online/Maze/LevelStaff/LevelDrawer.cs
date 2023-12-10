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

            Console.SetCursorPosition(level.Hero.CoordinateX, level.Hero.CoordinateY);
            ColorDetectionBySymbol(level.Hero);
            Console.Write(level.Hero.Symbol);

            PrintHP(level.Hero.Hp, 10);
            Console.CursorVisible = false;

            //Console.ReadLine();
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
                case "H":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                default:
                    Console.ResetColor();
                    break;
            }          
        }
        public void PrintHP(int value, int maxValue)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += " ";
            }

            Console.SetCursorPosition(0, 20);
            Console.Write('[');
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;


            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += " ";
            }
            Console.Write(bar + ']');
        }
    }
}

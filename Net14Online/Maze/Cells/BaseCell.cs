using Maze.Cells.Creatures;
using Maze.LevelStaff;
using System.Drawing;

namespace Maze.Cells
{
    public abstract class BaseCell
    {
        protected BaseCell(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.Green)
        {
            SymbolColor = color;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Level = level;
        }

        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public Level Level { get; }

        public abstract string Symbol { get; }

        public ConsoleColor SymbolColor { get; }

        public void DrawAlexandrGlazko()
        {
            Console.ResetColor();
            Console.ForegroundColor = SymbolColor;
            Console.Write(Symbol);
            Console.ResetColor();
        }

        public abstract bool Step(BaseCreature creature);
    }
}

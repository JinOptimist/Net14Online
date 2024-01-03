using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;

namespace Maze.LevelStaff
{
    public class LevelDrawer
    {
        private List<OldCell> _oldCells = new List<OldCell>();

        public void Draw(Level level)
        {
            var inputColor = Console.ForegroundColor;
            foreach (var cell in level.Cells)
            {
                var topCell = GetTopCellByCoordinate(level, cell.CoordinateX, cell.CoordinateY);
                RedrawCell(topCell);
            }
            Console.ResetColor();
            Console.SetCursorPosition(level.Width, level.Height - 1);
            DrawHeroStats(level.Hero);
            Console.ForegroundColor = inputColor;
        }

        private IBaseCell GetTopCellByCoordinate(Level level, int coordinateX, int coordinateY)
        {
            if (level.Hero.CoordinateX == coordinateX && level.Hero.CoordinateY == coordinateY)
            {
                return level.Hero;
            }

            var creature = level.Creatures.FirstOrDefault(c => c.CoordinateX == coordinateX && c.CoordinateY == coordinateY);
            if (creature is not null)
            {
                return creature;
            }

            var cell = level.Cells.FirstOrDefault(c => c.CoordinateX == coordinateX && c.CoordinateY == coordinateY);
            if (cell is not null)
            {
                return cell;
            }

            return null;
        }

        private void RedrawCell(IBaseCell cell)
        {
            if (cell is null)
            {
                return;
            }

            var oldCell = _oldCells.FirstOrDefault(c => c.CoordinateX == cell.CoordinateX && c.CoordinateY == cell.CoordinateY);
            if (oldCell is not null && oldCell.Symbol == cell.Symbol && oldCell.Color == cell.Color)
            {
                return;
            }
            if (oldCell is not null)
            {
                _oldCells.Remove(oldCell);
            }
            if (oldCell is null)
            {
                _oldCells.Add(new OldCell(cell.CoordinateX, cell.CoordinateY, cell.Symbol, cell.Color));
            }
            DrawCell(cell);
        }

        private void DrawCell(IBaseCell cell)
        {
            Console.SetCursorPosition(cell.CoordinateX, cell.CoordinateY);
            Console.ForegroundColor = cell.Color;
            Console.Write(cell.Symbol);
        }

        private void DrawHeroStats(IHero? hero)
        {
            if (hero != null)
            {
                Console.WriteLine();
                Console.Write("Hero has ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(hero.Money);
                Console.ResetColor();
                Console.Write(" dollars\n");
                Console.Write($"Hero has ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(hero.Hp);
                Console.ResetColor();
                Console.Write(" head points\n");
                Console.Write($"Hero has ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(hero.Age);
                Console.ResetColor();
                Console.Write(" years\n");
            }
        }
    }

    public class OldCell
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public string Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        public OldCell(int coordinateX, int coordinateY, string symbol, ConsoleColor color)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Symbol = symbol;
            Color = color;
        }

        private void DrawingColorCells(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        
    }
}

using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;

namespace Maze.LevelStaff
{
    public class LevelDrawer
    {
        private List<IBaseCell> _cellsForRedraw;
        private int _countCellsForRedraw;
        private int _countCreaturesForRedraw;

        public LevelDrawer()
        {
            _cellsForRedraw = new List<IBaseCell>();
        }

        public void Draw(Level level)
        {
            AddStateForCells(level);
            foreach (var cell in _cellsForRedraw)
            {
                DrawCell(cell);
            }
            DrawCell(level.Hero);
            _cellsForRedraw.Clear();
            Console.ResetColor();
            Console.SetCursorPosition(level.Width, level.Height - 1);
            DrawHeroStats(level.Hero);
        }

        private void AddStateForCells(Level level)
        {
            if (_countCellsForRedraw != level.Cells.Count)
            {
                AddState(level.Cells.GetRange(_countCellsForRedraw, level.Cells.Count - _countCellsForRedraw));
                _countCellsForRedraw = level.Cells.Count;
            }
            if (_countCreaturesForRedraw != level.Creatures.Count + 1)
            {
                AddState(level.Creatures.GetRange(_countCreaturesForRedraw, level.Creatures.Count - _countCreaturesForRedraw));
                var hero = level.Hero;
                hero.State -= RedrawCell;
                hero.State += RedrawCell;
                hero.StateUpdate();
                _countCreaturesForRedraw = level.Creatures.Count + 1;
            }
        }

        private void AddState<CellType>(List<CellType> cells) where CellType : IBaseCell
        {
            foreach (var cell in cells)
            {
                cell.State -= RedrawCell;
                cell.State += RedrawCell;
                cell.StateUpdate();
            }
        }

        private void RedrawCell(IBaseCell newPositionCell)
        {
            if (newPositionCell.Level == null)
            {
                return;
            }
            _cellsForRedraw.Add(newPositionCell);
            if (newPositionCell.Level.Hero != null)
            {
                var oldHero = newPositionCell.Level.Hero;
                if (oldHero.CoordinateX == newPositionCell.OldCoordinateX && oldHero.CoordinateY == newPositionCell.OldCoordinateY)
                {
                    _cellsForRedraw.Add(oldHero);
                    return;
                }
            }
            if (AddRedrawCell(newPositionCell.Level.Cells, newPositionCell.OldCoordinateX, newPositionCell.OldCoordinateY))
            {
                return;
            }
            if (AddRedrawCell(newPositionCell.Level.Creatures, newPositionCell.OldCoordinateX, newPositionCell.OldCoordinateY))
            {
                return;
            }
        }

        private bool AddRedrawCell<CellType>(List<CellType> cells, int oldPositionX, int oldPositionY) where CellType : IBaseCell
        {
            var cell = GetRedrawCell(cells, oldPositionX, oldPositionY);
            if (cell != null)
            {
                _cellsForRedraw.Add(cell);
                return true;
            }
            return false;
        }

        private IBaseCell? GetRedrawCell<CellType>(List<CellType> cells, int positionX, int positionY) where CellType : IBaseCell
        {
            return cells.FirstOrDefault(c => c.CoordinateX == positionX && c.CoordinateY == positionY);
        }

        private void DrawCell(IBaseCell? cell)
        {
            if (cell != null)
            {
                Console.SetCursorPosition(cell.CoordinateX, cell.CoordinateY);
                Console.ForegroundColor = cell.Color;
                Console.Write(cell.Symbol);
            }
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
}

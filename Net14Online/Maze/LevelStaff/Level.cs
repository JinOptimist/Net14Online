using Maze.Cells;
using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;

namespace Maze.LevelStaff
{
    public class Level : ILevel
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<IBaseCell> Cells { get; set; } = new List<IBaseCell>();
        public List<IBaseCreature> Creatures { get; set; } = new List<IBaseCreature>();
        public IHero Hero { get; set; }

        public void ReplaceCell(IBaseCell oldCell, IBaseCell newCell)
        {
            Cells.Remove(oldCell);
            Cells.Add(newCell);
        }

        public void ReplaceToGround(IBaseCell cell)
        {
            var ground = new Ground(cell.CoordinateX, cell.CoordinateY, this);
            ReplaceCell(cell, ground);
        }

        public List<OneOfCellType> GetNearCells<OneOfCellType>(IBaseCell currentCell)
           where OneOfCellType : IBaseCell
        {
            return Cells
                .Where(cell => cell.CoordinateX == currentCell.CoordinateX
                    && Math.Abs(cell.CoordinateY - currentCell.CoordinateY) == 1
                    ||
                    Math.Abs(cell.CoordinateX - currentCell.CoordinateX) == 1
                    && cell.CoordinateY == currentCell.CoordinateY)
                .OfType<OneOfCellType>()
                .ToList();
        }

        internal void ReplaceCell(IBaseCell randomGround, Chest chest)
        {
            throw new NotImplementedException();
        }
    }
}

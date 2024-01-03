using Maze.Cells;
using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;

namespace Maze.LevelStaff
{
    public interface ILevel
    {
        List<IBaseCell> Cells { get; set; }
        List<IBaseCreature> Creatures { get; set; }
        int Height { get; set; }
        IHero Hero { get; set; }
        int Width { get; set; }

        List<OneOfCellType> GetNearCells<OneOfCellType>(IBaseCell currentCell) where OneOfCellType : IBaseCell;
        void ReplaceCell(IBaseCell oldCell, IBaseCell newCell);
        void ReplaceToGround(IBaseCell cell);
    }
}
using Maze.LevelStaff;

namespace Maze.Cells;

public class Fountain : BaseCell
{
    public Fountain(int coordinateX, int coordinateY, Level level) : base(coordinateX, coordinateY, level)
    {
    }

    public override string Symbol => "@";
}
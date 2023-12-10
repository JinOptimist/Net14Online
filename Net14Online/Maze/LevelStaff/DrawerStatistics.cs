using Maze.Cells.Creatures;

namespace Maze.LevelStaff;

public class DrawerStatistics
{
    public void DrawerStatisticsHero(Level level)
    {
        Console.SetCursorPosition(0,level.Height);
        
        Console.WriteLine($"HP Hero:{level.Hero.Hp}");
        Console.WriteLine($"Money Hero:{level.Hero.Money}");
       
        Console.SetCursorPosition(level.Hero.CoordinateX,level.Hero.CoordinateY);
        Console.Write(level.Hero.Symbol);
    }
}
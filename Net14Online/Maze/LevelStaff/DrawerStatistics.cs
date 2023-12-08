using Maze.Cells.Creatures;

namespace Maze.LevelStaff;

public class DrawerStatistics
{
    public void DrawerStatisticsHero(BaseCreature baseCreature)
    {
        Console.SetCursorPosition(0,baseCreature.Level.Height);
        
        Console.WriteLine($"HP Hero:{baseCreature.Hp}");
        Console.WriteLine($"Money Hero:{baseCreature.Money}");
       
        Console.SetCursorPosition(baseCreature.Level.Hero.CoordinateX,baseCreature.Level.Hero.CoordinateY);
        Console.Write(baseCreature.Level.Hero.Symbol);
    }
}
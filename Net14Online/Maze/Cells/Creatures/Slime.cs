using Maze.LevelStaff;
using System;

namespace Maze.Cells.Creatures
{
    internal class Slime : BaseCreature
    {
        public const ConsoleColor DEFAULT_ATTACK_COLOR = ConsoleColor.Red;

        private ConsoleColor startColor;

        public Slime(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.Blue) 
            : base(coordinateX, coordinateY, level, color)
        {
            startColor = color;
        }

        public override string Symbol => "S";

        public override BaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<Ground>(this);
            if (cells.Count == 0)
                return null;
            var cell = cells[0];
            return cell;
        }

        public override bool Step(BaseCreature creature)
        {
            Console.WriteLine(creature);
            if (creature is Hero)
            {
                Color = DEFAULT_ATTACK_COLOR;
                creature.Hp--;
                return false;
            }

            Color = startColor;

            return false;
        }
    }
}
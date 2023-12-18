using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.Helper;
using Maze.LevelStaff;
using System;

namespace Maze.Cells.Creatures
{
    public class Slime : BaseCreature
    {
        public const ConsoleColor DEFAULT_ATTACK_COLOR = ConsoleColor.Red;

        private ConsoleColor startColor;

        public Slime(int coordinateX, int coordinateY, ILevel level, ConsoleColor color = ConsoleColor.Blue) 
            : base(coordinateX, coordinateY, level, color)
        {
            startColor = color;
        }

        public override string Symbol => "S";

        public override IBaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<IBaseCell>(this);
            return cells.GetRandom();
        }

        public override bool Step(IBaseCreature creature)
        {
            var hero = creature as Hero;
            if (hero != null)
            {
                Color = DEFAULT_ATTACK_COLOR;
                hero.Hp--;
                return false;
            }

            Color = startColor;

            return false;
        }
    }
}
using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells
{
    internal class Sun : BaseCell
    {
        private const int _giveHappiness = 5;
        public Sun(int coordinateX, int coordinateY, ILevel level, ConsoleColor color = ConsoleColor.Yellow) : base(coordinateX, coordinateY, level, color)
        { }

        public override string Symbol => "☀";

        public override bool Step(IBaseCreature creature)
        {
            var hero = creature as Hero;

            if (hero is not null)
            {
                if (hero.Stress - _giveHappiness >= Hero.MinHeroStress)
                {
                    hero.Stress -= _giveHappiness;
                }
                else hero.Stress = Hero.MinHeroStress;
               

                var ground = new Ground(CoordinateX, CoordinateY, Level);
                Level.ReplaceCell(this, ground);
            }
            
            var witch = creature as Witch;

            if (witch is not null)
            {
                var ground = new Ground(CoordinateX, CoordinateY, Level);
                Level.ReplaceCell(this, ground);
            }

            return true;
        }
    }
}

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
    internal class UglySun : BaseCell
    {
        private int _giveStress = 5;
        public UglySun(int coordinateX, int coordinateY, ILevel level, ConsoleColor color = ConsoleColor.DarkYellow) : base(coordinateX, coordinateY, level, color)
        { }

        public override string Symbol => "U";

        public override bool Step(IBaseCreature creature)
        {
            var hero = creature as Hero;
            if (hero is not null)
            {
                if (hero.Stress + _giveStress <= 100)
                {
                    hero.Stress += _giveStress;
                }
                else hero.Stress = 100;

                var ground = new Ground(CoordinateX, CoordinateY, Level);
                Level.ReplaceCell(this, ground);
            }

           
            return true;
        }
    }
}

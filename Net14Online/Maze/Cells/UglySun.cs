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
        private const int _giveStress = 5;
        public UglySun(int coordinateX, int coordinateY, ILevel level, ConsoleColor color = ConsoleColor.DarkYellow) : base(coordinateX, coordinateY, level, color)
        { }

       
        public override string Symbol
        {
            get
            {
                const string darkRedColor = "\u001b[31m";
                const string resetColor = "\u001b[0m";
                const string uglySunCharacter = "¤";

                return $"{darkRedColor}{uglySunCharacter}{resetColor}";
            }
        }
        public override bool Step(IBaseCreature creature)
        {
            var hero = creature as Hero;
            if (hero is not null)
            {
                if (hero.Stress + _giveStress <= Hero.MaxHeroStress)
                {
                    hero.Stress += _giveStress;
                }
                else hero.Stress = Hero.MaxHeroStress;

                var ground = new Ground(CoordinateX, CoordinateY, Level);
                Level.ReplaceCell(this, ground);
            }

           
            return true;
        }
    }
}

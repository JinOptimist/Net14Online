using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Maze.Cells.Creatures
{
    public class Witch : BaseCreature
    {
        private const int  _giveStress = 10;
        private const int _takeHp = 5;
        private Random _random = new Random();
        public Witch(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.DarkCyan)
            : base(coordinateX, coordinateY, level, color)
        {
        }

        public override string Symbol => "W";

        public override IBaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<BaseCell>(this);
            var randomInex = _random.Next(cells.Count);
            var cell = cells[randomInex];
            return cell;
        }

        public override bool Step(IBaseCreature creature)
        {
            var hero = creature as Hero;

            if (hero is not null)
            {
                if (hero.Hp - _takeHp > 0)
                {
                    hero.Hp -= _takeHp;
                }
                else hero.Hp = 0;

                if (hero.Stress + _giveStress <= Hero.MaxHeroStress)
                {
                    hero.Stress += _giveStress;
                }
                else hero.Stress = Hero.MaxHeroStress;

                return true;
            }

            return false;
        }
    }
}
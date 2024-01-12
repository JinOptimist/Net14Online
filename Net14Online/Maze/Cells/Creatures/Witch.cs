using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells.Creatures
{
    public class Witch : BaseCreature
    {
        private Random _random = new Random();
        private const int _GIVE_STRESS = 10;
        private const int _TAKE_HP = 5;
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
                creature.Hp -= 2;
                if (hero.Hp - _TAKE_HP > 0)
                {
                    hero.Hp -= _TAKE_HP;
                }
                else
                {
                    hero.Hp = 0;
                }

                if (hero.Stress + _GIVE_STRESS <= Hero.MAX_HERO_STRESS)
                {
                    hero.Stress += _GIVE_STRESS;
                }
                else
                {
                    hero.Stress = Hero.MAX_HERO_STRESS;
                }

                return true;
            }

            return false;
        }



    }
    }

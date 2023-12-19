using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.Helper;
using Maze.LevelStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Cells.Creatures
{
    public class Banker : BaseCreature
    {
        // переопределение символа для текущего существа
        public override string Symbol => "$";

        // создаем приватный объект рандома, доступный только внутри класса
        private Random _random = new Random();
        
        // создаем конструктор
        public Banker(int coordinateX, int coordinateY, Level level, ConsoleColor color = ConsoleColor.Yellow) : base(coordinateX, coordinateY, level, color)
        {
        }
        // создаем метод, который определяет первоначальную точку размещения существа
        public override IBaseCell ChooseCellToStep()
        {
            var cells = Level.GetNearCells<Ground>(this);
            if (cells.Any())
            {
                return cells.GetRandom();
            }

            //If we hasn't Ground on near cells stay on the same cells
            return Level.Cells.First(x => x.CoordinateX == CoordinateX && x.CoordinateY == CoordinateY);
        }
        /// <summary>
        /// метод совершения действий с близлежащим героем: дает 50 ед. денег, если у героя меньше 50 в наличии, и отнимает 50 единиц - если у героя более 50 ед. денег
        /// </summary>
        /// <param name="creature"></param>
        /// <returns></returns>
        public override bool Step(IBaseCreature creature)
        {
            var hero = creature as Hero;
            if (hero == null)
            {
                return false;
            }
            hero.Money = hero.Money < 50 
                ? hero.Money + 50 
                : hero.Money - 50;
            return false;
        }
    }
}

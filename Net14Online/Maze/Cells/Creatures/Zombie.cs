using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.Cells.Creatures
{
    public class Zombie : BaseCreature
    {
        public override string Symbol => "Z";
        private Random _random = new Random();
        private readonly Level _level;

        public Zombie(int coordinateX, int coordinateY, Level level, ConsoleColor color) : base(coordinateX, coordinateY, level, ConsoleColor.DarkGreen)
        {
            _level = level;
        }

        public override IBaseCell ChooseCellToStep()
        {
            var zombie = _level.Creatures.First(x => x is Zombie);
            var cellToStep = _level.Cells.First(x => x.CoordinateX == zombie.CoordinateX + 1 && x.CoordinateY == zombie.CoordinateY);
            if (cellToStep is Ground)
            {
                zombie.CoordinateX = cellToStep.CoordinateX;
                zombie.CoordinateY = cellToStep.CoordinateY;
                return cellToStep;
            }
            else
            {
                cellToStep = _level.Cells.First(x => x.CoordinateX == zombie.CoordinateX - 1 && x.CoordinateY == zombie.CoordinateY);
                if (cellToStep is Ground)
                {
                    zombie.CoordinateX = cellToStep.CoordinateX;
                    zombie.CoordinateY = cellToStep.CoordinateY;

                }
                else
                {
                    cellToStep = _level.Cells.First(x => x.CoordinateX == zombie.CoordinateX && x.CoordinateY == zombie.CoordinateY + 1);
                    if (cellToStep is Ground)
                    {
                        zombie.CoordinateX = cellToStep.CoordinateX;
                        zombie.CoordinateY = cellToStep.CoordinateY;

                    }
                    else
                    {
                        cellToStep = _level.Cells.First(x => x.CoordinateX == zombie.CoordinateX && x.CoordinateY == zombie.CoordinateY - 1);
                        if (cellToStep is Ground)
                        {
                            zombie.CoordinateX = cellToStep.CoordinateX;
                            zombie.CoordinateY = cellToStep.CoordinateY;

                        }
                    }
                }
                return cellToStep;
            }
        }

        public override bool Step(IBaseCreature creature)
        {
            var hero = creature as Hero;

            if (hero != null)
            {
                hero.Hp--;

                var zombie = Level.Creatures.First(x => x is Zombie);
                var stepCell = Level.Cells.First(x => x.CoordinateX == zombie.CoordinateX && x.CoordinateY == zombie.CoordinateY);

                var potentionalCellsForCoin = Level.GetNearCells<IBaseCell>(stepCell);
                var newCoinCell = potentionalCellsForCoin[_random.Next(potentionalCellsForCoin.Count)];

                var newCoin = new Coin(newCoinCell.CoordinateX, newCoinCell.CoordinateY, newCoinCell.Level);
                Level.Cells.Remove(newCoinCell);
                Level.Cells.Add(newCoinCell);

                return false;
            }

            return false;
        }
    }
}

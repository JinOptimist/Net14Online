using Maze.Cells;
using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;

namespace Maze.ConsolePlay
{
    public class ConsoleController
    {
        private Level _level;
        public void Play()
        {
            var builder = new LevelBuilder();
            var drawer = new LevelDrawer();

            _level = builder.ChoiseLevelBuilder();
            drawer.Draw(_level);

            var isGameOver = false;
            while (!isGameOver)
            {
                if (_level.Hero.Stress >=Hero.MaxHeroStress)
                {
                    isGameOver = true;
                    Console.Clear();
                    Console.WriteLine("Your hero has reached the maximum stress level! He refuses to go anywhere in the labyrinth!");
                    Console.WriteLine("GAME OVER!!!");
                    return;
                }
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        Step(Direction.Left);
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        Step(Direction.Right);
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        Step(Direction.Up);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        Step(Direction.Down);
                        break;
                    case ConsoleKey.Escape:
                        isGameOver = true;
                        break;
                }
                drawer.Draw(_level);
            }
          
        }

        private void Step(Direction direction)
        {
            CheckHeroChanceToMakeOneStep(direction);

            foreach (var creature in _level.Creatures)
            {
                
                var cell = creature.ChooseCellToStep();
                MoveCreature(creature, cell);
            }

        }

        private void MoveCreature(IBaseCreature creature, IBaseCell destinationCell)
        {
            if (destinationCell == null)
            {
                return;
            }

            if (destinationCell.Step(creature))
            {
                creature.CoordinateX = destinationCell.CoordinateX;
                creature.CoordinateY = destinationCell.CoordinateY;
            }
        }

        private void CheckHeroChanceToMakeOneStep(Direction direction)
        {
            var destinationX = _level.Hero.CoordinateX;
            var destinationY = _level.Hero.CoordinateY;
            Random random = new();
            var randomChanceToMakeOneStep = random.Next(Hero.MinHeroStress, Hero.MaxHeroStress);
            if ((randomChanceToMakeOneStep > _level.Hero.Stress) || (_level.Hero.Stress == Hero.MinHeroStress))
            {
                switch (direction)
                {
                    case Direction.Left:
                        destinationX--;
                        break;
                    case Direction.Right:
                        destinationX++;
                        break;
                    case Direction.Up:
                        destinationY--;
                        break;
                    case Direction.Down:
                        destinationY++;
                        break;
                }

                var destinationCell = _level.Cells
                   .SingleOrDefault(x => x.CoordinateX == destinationX && x.CoordinateY == destinationY);

                MoveCreature(_level.Hero, destinationCell);
            }

        }
    }
}

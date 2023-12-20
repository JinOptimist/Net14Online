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

                CheckStress(isGameOver);
                
            }

        }

        private void Step(Direction direction)
        {
            HeroStep(direction);

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

        private void HeroStep(Direction direction)
        {
            var destinationX = _level.Hero.CoordinateX;
            var destinationY = _level.Hero.CoordinateY;

            Random random = new();
            var relativeStress = (double)(_level.Hero.Stress - Hero.MIN_HERO_STRESS) / (Hero.MAX_HERO_STRESS - Hero.MIN_HERO_STRESS);
            var randomChanceToMakeOneStep = random.NextDouble();
            var probabilityLimit = 1.0 - relativeStress;

            if (!(randomChanceToMakeOneStep > probabilityLimit))
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

        private void CheckStress(bool isGameOver)
        {
            if (_level.Hero.Stress >= Hero.MAX_HERO_STRESS)
            {
                isGameOver = true;
                Console.Clear();

                var stressText = "Your hero has reached the maximum stress level! He refuses to go anywhere in the labyrinth!";
                var gameOverText = "GAME OVER!!!";

                var centerX = Console.WindowWidth / 2 - stressText.Length / 2;
                var centerY = Console.WindowHeight / 2;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(centerX, centerY);
                Console.WriteLine(stressText);
                centerX = Console.WindowWidth / 2 - gameOverText.Length / 2;
                centerY += 2;
                Console.SetCursorPosition(centerX, centerY);
                Console.WriteLine(gameOverText);
                Console.ResetColor();
                Console.ReadLine();
                return;
            }
        }
    }
}

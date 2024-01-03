using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using System;

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
                if (_level.Hero.Hp <= 0)
                {
                    isGameOver = true;
                    break;
                }
                if (_level.Hero.Stress >= Hero.MAX_HERO_STRESS)
                {
                    isGameOver = true;
                    break;
                }
                var key = Console.ReadKey(true);
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
            Console.Clear();
            Console.Write("Game over");
            if (_level.Hero.Hp <= 0)
            {
                Console.WriteLine("Game over, Hero is dead");
                return;
            }
            if (_level.Hero.Stress >= Hero.MAX_HERO_STRESS)
            {
                Console.Clear();
                ShowSressMessage("Your hero has reached the maximum stress level! He refuses to go anywhere in the labyrinth!", ConsoleColor.Red, 0);
                ShowSressMessage("GAME OVER!!!", ConsoleColor.Red, 2);
                Console.ResetColor();
                Console.ReadKey();
                return;
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
        private void ShowSressMessage(string message, ConsoleColor textColor, int moveMessage)
        {
            var centerX = Console.WindowWidth / 2 - message.Length / 2;
            var centerY = Console.WindowHeight / 2 + moveMessage;
            Console.ForegroundColor = textColor;
            Console.SetCursorPosition(centerX, centerY);
            Console.WriteLine(message);

        }
    }
}

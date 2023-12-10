using Maze.LevelStaff;
using System.Reflection.Emit;

namespace Maze.ConsolePlay
{
    public class ConsoleController
    {
        private Level _level;
        public void Play()
        {
            var builder = new LevelBuilder();
            var drawer = new LevelDrawer();

            _level = builder.BuildV0(16, 16);
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
            }
        }

        private void Step(Direction direction)
        {
            var destinationX = _level.Hero.CoordinateX;
            var destinationY = _level.Hero.CoordinateY;

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

            if (destinationCell == null)
            {
                return;
            }

            if (destinationCell.Step(_level.Hero))
            {
                _level.Hero.CoordinateX = destinationX;
                _level.Hero.CoordinateY = destinationY;
            }
        }
    }
}

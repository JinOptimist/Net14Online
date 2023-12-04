using Maze.Cells;
using System.Drawing;

namespace Maze.LevelStaff
{
    public class LevelBuilder
    {
        private Level _level;
        private Random _random;

        public Level BuildV0(int width = 10, int height = 5, int seedForRandom = -1)
        {
            if (seedForRandom > 0)
            {
                _random = new Random(seedForRandom);
            }
            else
            {
                _random = new Random();
            }

            _level = new Level();

            _level.Width = width;
            _level.Height = height;

            BuildWall();
            BuildGroundRandom();

            return _level;
        }

        public Level BuildV17(int width = 10, int height = 5, int seedForRandom = -1, int numberOfSecrets = 2)
        {
            if (seedForRandom > 0)
            {
                _random = new Random(seedForRandom);
            }
            else
            {
                _random = new Random();
            }

            _level = new Level();
            _level.Width = width;
            _level.Height = height;

            BuildWall();
            BuildSecret(numberOfSecrets);

            return _level;
        }

        private void BuildGroundRandom()
        {
            for (int i = 0; i < 15; i++)
            {
                var randomX = _random.Next(_level.Width);
                var randomY = _random.Next(_level.Height);

                var randomWall = _level.Cells.First(x => x.CoordinateX == randomX && x.CoordinateY == randomY);
                var ground = new Ground(randomX, randomY, _level);

                _level.Cells.Remove(randomWall);
                _level.Cells.Add(ground);
            }
        }

        private void ChangeWallCell(Point position, BaseCell newCell)
        {
            var wallCell = _level.Cells.SingleOrDefault(x => x.CoordinateX == position.X && x.CoordinateY == position.Y && x is Wall);

            if (wallCell != null)
            {
                _level.Cells.Remove(wallCell);
                _level.Cells.Add(newCell);
            }
        }

        private void BuildWall()
        {
            for (int x = 0; x < _level.Width; x++)
            {
                for (int y = 0; y < _level.Height; y++)
                {
                    var cell = new Wall(x, y, _level);

                    _level.Cells.Add(cell);
                }
            }
        }

        private void BuildSecret(int numberOfSecrets)
        {
            for (int i = 0; i < numberOfSecrets; i++)
            {
                var randomX = _random.Next(1, _level.Width - 1);
                var randomY = _random.Next(1, _level.Height - 1);
                Point position = new Point(randomX, randomY);
                Secret secret = AddSecret(position);

                Point startPathPosition = new Point(_level.Width / 2, _level.Height / 2);
                Point endPathPosition = new Point(secret.CoordinateX, secret.CoordinateY);
                BuildPaths(startPathPosition, endPathPosition);
            }
        }

        private Secret AddSecret(Point position)
        {
            var oldCell = _level.Cells.First(x => x.CoordinateX == position.X && x.CoordinateY == position.Y);
            var secret = new Secret(position.X, position.Y, _level);

            _level.Cells.Remove(oldCell);
            _level.Cells.Add(secret);

            return secret;
        }

        private void BuildPaths(Point startPosition, Point endPosition)
        {
            ChangeWallCell(startPosition, new Ground(startPosition.X, startPosition.Y, _level));

            int direction = 0;
            if ((direction = GetDirection(startPosition.X, endPosition.X)) != 0)
            {
                startPosition.X += direction;
                BuildPaths(startPosition, endPosition);
                return;
            }

            if ((direction = GetDirection(startPosition.Y, endPosition.Y)) != 0)
            {
                startPosition.Y += direction;
                BuildPaths(startPosition, endPosition);
                return;
            }
        }

        private int GetDirection(int startPosition, int endPosition)
        {
            if (startPosition < endPosition)
            {
                return 1;
            }

            if (startPosition > endPosition)
            {
                return -1;
            }

            return 0;
        }
    }
}


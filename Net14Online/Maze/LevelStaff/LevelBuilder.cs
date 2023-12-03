using Maze.Cells;

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

        public Level BuildV1(int width = 10, int height = 5, int seedForRandom = -1, int numberOfSecrets = 2)
        {
            if (seedForRandom > 0)
                _random = new Random(seedForRandom);
            else
                _random = new Random();

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

        private void BuildGround((int x, int y) position)
        {
            if (position.x < 0 || position.y < 0)
                return;

            var oldCell = _level.Cells.FirstOrDefault(x => x.CoordinateX == position.x && x.CoordinateY == position.y);
            var ground = new Ground(position.x, position.y, _level);

            if (oldCell is Wall)
            {
                _level.Cells.Remove(oldCell);
                _level.Cells.Add(ground);
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
                Secret secret = InitializeSecret((randomX, randomY));
                BuildPaths((_level.Width / 2, _level.Height / 2), (secret.CoordinateX, secret.CoordinateY));
            }
        }

        private Secret InitializeSecret((int x, int y) position)
        {
            var oldCell = _level.Cells.First(x => x.CoordinateX == position.x && x.CoordinateY == position.y);
            var secret = new Secret(position.x, position.y, _level);

            _level.Cells.Remove(oldCell);
            _level.Cells.Add(secret);

            return secret;
        }

        private void BuildPaths((int x, int y) startPosition, (int x, int y) endPosition)
        {
            BuildGround((startPosition.x, startPosition.y));

            int direction = 0;
            if ((direction = GetDirection((startPosition.x, endPosition.x))) != 0)
            {
                BuildPaths((startPosition.x + direction, startPosition.y), (endPosition.x, endPosition.y));
                return;
            }

            if ((direction = GetDirection((startPosition.y, endPosition.y))) != 0)
            {
                BuildPaths((startPosition.x, startPosition.y + direction), (endPosition.x, endPosition.y));
                return;
            }
        }

        private int GetDirection((int startPos, int endPos) position)
        {
            int direction = 0;
            if (position.startPos != position.endPos)
                direction = position.startPos < position.endPos ? 1 : -1;
            return direction;
        }
    }
}

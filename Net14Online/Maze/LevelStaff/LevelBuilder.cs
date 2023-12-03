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
            BuildPuddle();
            BuildGroundRandom();

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
        private void BuildPuddle()
        {
            for (int i = 0; i < 5; i++)
            {
                
                for (int k = 0; k < _level.Height; k++)
                {
                    Console.SetCursorPosition(_level.Height - k, k + 1);
                    for (int j = 0; j <= k * 2; j++)
                    {
                        var cell = new PuddleV10(j, k, _level);
                        _level.Cells.Add(cell);
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}

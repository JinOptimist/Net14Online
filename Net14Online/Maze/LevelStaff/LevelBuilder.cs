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
            BuildRing();

            return _level;
        }
        public Level BuildV11(int width = 10, int height = 5)
        {

            _level = new Level();

            _level.Width = width;
            _level.Height = height;

            BuildWall();
            BuildRing();

            return _level;
        }


        private void BuildRing()
        {
            for (int i = 0; i < 15; i++)
            {
                var randomX = 0;
                var randomY = 0;

                for (int j = 0; j < 5; j++) 
                {
                    var randomWall = _level.Cells.First(x => x.CoordinateX == randomX && x.CoordinateY == randomY);
                    var ground = new Ring(randomX, randomY, _level);

                    _level.Cells.Remove(randomWall);
                    _level.Cells.Add(ground);

                    randomX += 2;
                    randomY += 1;
                }
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
    }
}

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
            BuildFountain();
            BuildGroundV6();

            return _level;
        }

        private void BuildGroundV6()
        {
            for (int i = 0; i < _level.Width; i++)
            {
                for (int j = 0; j < _level.Height; j++)
                {
                    if (i == 0 || j == _level.Height - 1)
                    {
                        var positionX = i;
                        var positionY = j;
                       
                        var randomWall = _level.Cells.First(x => x.CoordinateX == positionX && x.CoordinateY == positionY);
                        var ground = new Ground(positionX, positionY, _level);

                        _level.Cells.Remove(randomWall);
                        _level.Cells.Add(ground);
                        
                    }
                }
            }
        }

        private void BuildFountain()
        {
            var centreInWidth = _level.Width / 2;
            var centreInHeight = _level.Height / 2;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    var randomWall = _level.Cells.First(x => x.CoordinateX == centreInWidth + i && x.CoordinateY == centreInHeight + i);
                    var ground = new Ground(centreInWidth + i, centreInHeight + i, _level);

                    _level.Cells.Remove(randomWall);
                    _level.Cells.Add(ground); 
                }
            }
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
    }
}

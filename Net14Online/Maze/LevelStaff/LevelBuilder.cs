using Maze.Cells;
using System;

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
            BuildGroundV4();
            BuildHeartsV4();
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

        private void BuildGroundV4()
        {
            var randomY = _random.Next(_level.Height);
            var randomX = 0;

            var randomStep = 2;
            do
            {
                SetWallsV4(randomX, randomY);

                randomX += _random.Next(randomStep);
                randomY += _random.Next(randomStep);

                if (randomX == 0)
                {
                    randomX++;
                }

            }
            while (!FindExitV4(randomX, randomY));

            SetWallsV4(randomX, randomY);

        }

        private void BuildHeartsV4()
        {
            var maxHearts = 2;
            var heartsCounter = 0;
            for(int i = 0; i < _level.Cells.Count; i++)
            {
                if (_level.Cells[i] is Ground && heartsCounter < maxHearts)
                {
                    var cell = _level.Cells[i];
                    
                    var heart = new Heart(cell.CoordinateX, cell.CoordinateY, _level);
                    _level.Cells.Remove(cell);
                    _level.Cells.Add(heart);            

                    heartsCounter++;
                }
            }
        }

        private void SetWallsV4(int x, int y)
        {

            var randomWall = _level.Cells.FirstOrDefault(c => c.CoordinateX == x && c.CoordinateY == y);
            if (randomWall is null)
            {
                return;
            }
            var ground = new Ground(x, y, _level);

            _level.Cells.Remove(randomWall);
            _level.Cells.Add(ground);

        }

        private bool FindExitV4(int x, int y)
        {
            if (x == _level.Width - 1 || x == 0)
            {
                return true;
            }

            if (y == _level.Height - 1 || y == 0)
            {
                return true;
            }

            return false;
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

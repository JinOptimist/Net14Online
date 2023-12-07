using Maze.Cells;
using System;

namespace Maze.LevelStaff
{
    public class LevelBuilder
    {
        private Level _level;

        public Level BuildV0(int width = 10, int height = 5)
        {
            _level = new Level();

            _level.Width = width;
            _level.Height = height;

            BuildWall();
            BuildGroundRandom();
            BuildPortal();

            return _level;
        }


        private void BuildGroundRandom()
        {

            for (int i = 0; i < _level.Width; i++)
            {
                int Y = 1;
                if (i != 0 && i % 4 != 0 && i < _level.Width - 1)
                {
                    int X = i;
                    var ground = new Ground(X, Y, _level);
                    var certainWall = _level.Cells.First(x => x.CoordinateX == X && x.CoordinateY == Y);
                    _level.Cells.Remove(certainWall);
                    _level.Cells.Add(ground);
                }
            }

            for (int i = 0; i < _level.Height - 4; i++)
            {
                int Y = i + 2;
                for (int j = 0; j < _level.Width; j++)
                {
                    int X = j;
                    if (j != 0 && j % 2 != 0 && j < _level.Width - 1 && j != _level.Width && X< _level.Width - 1)
                    {
                        var ground = new Ground(X, Y, _level);
                        var certainWall = _level.Cells.First(x => x.CoordinateX == X && x.CoordinateY == Y);
                        _level.Cells.Remove(certainWall);
                        _level.Cells.Add(ground);
                    }
                }
            }
            for (int i = 0; i < _level.Width; i++)
            {
                int Y = _level.Height - 2;
                if (i != 0 && (i+2) % 4 != 0 && i < _level.Width - 1)
                {
                    int X = i;
                    var ground = new Ground(X, Y, _level);
                    var certainWall = _level.Cells.First(x => x.CoordinateX == X && x.CoordinateY == Y);
                    _level.Cells.Remove(certainWall);
                    _level.Cells.Add(ground);
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

        private void BuildPortal()
        {
            int x = 0;
            int y = 0;
            if ((_level.Width - 3) % 4 == 0 || (_level.Width - 4) % 4 == 0)
            {
                x = _level.Width - 2;
                y = 1;               
            }
            else if((_level.Width - 5) % 4 == 0 || (_level.Width - 6) % 4 == 0)
            {
                x = _level.Width - 2;
                y = _level.Height - 2;               
            }
            var cell = new Portal(x, y, _level);
            _level.Cells.Add(cell);
        }
    }
}

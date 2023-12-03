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
        private void BuildGroundV2()
        {
            var points = new List<Point>();
            points.Add(new Point(2, 3));
            points.Add(new Point(4, 7));
            points.Add(new Point(6, 9));
            foreach (var point in points)
                { 
                    var existingCell = _level.Cells.First(cell => cell.CoordinateX == point.X && cell.CoordinateY == point.Y);
                    var ground = new Ground(point.X, point.Y, _level);
                    _level.Cells.Remove(existingCell);
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
        private void BuildDiamond() 
        {
            foreach (var cell in _level.Cells)
            {
                var moveX = new[] { 1, 0, -1 };
                var moveY = new[] { 0, 1, -1 };
                foreach (int x in moveX)
                { 
                    foreach(int y in moveY)
                    {
                        int newX = cell.CoordinateX + x;
                        int newY = cell.CoordinateY + y;
                        var existingCell = _level.Cells.First(cell => cell.CoordinateX == newX && cell.CoordinateY == newY);
                        var diamond = new Diamond(newX, newY, _level);
                        _level.Cells.Remove(existingCell);
                        _level.Cells.Add(diamond);
                    }
                    
                }
                
            }
        }
    }
}

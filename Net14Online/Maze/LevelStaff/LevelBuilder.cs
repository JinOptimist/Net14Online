using Maze.Cells;
using System.Drawing;

namespace Maze.LevelStaff
{
    public class LevelBuilder
    {
        private Level _level;
        private Random _random;

        public Level BuildV0(int width = 10, int height = 5, int seedForRandom = -1, int coinCount = 2)
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
            BuildGroundV2();
            BuildDiamond();
            BuildGroundRandom();
            BuildCoin(coinCount);

            return _level;
        }

        public Level BuildV18(int width = 10, int height = 5, int seedForRandom = -1)
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
            BuildGroundV18();
            BuildCage();

            return _level;
        }

        public Level BuildV7(int width = 10, int height = 5, int seedForRandom = -1)
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
            BuildGroundRandomV7();
            AddBerriesV7(3);

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
            points.Add(new Point(1, 2));
            points.Add(new Point(3, 3));
            points.Add(new Point(2, 4));
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


        private void AddGroundCellV7(int x, int y)
        {
            var wallToRemove = _level.Cells.First(cell => cell.CoordinateX == x && cell.CoordinateY == y);
            var ground = new Ground(x, y, _level);

            _level.Cells.Remove(wallToRemove);
            _level.Cells.Add(ground);
        }

        private void BuildGroundRandomV7()
        {
            for (int y = 1; y < _level.Height-1; y=y+2)
            {
                for (int x = 1; x < _level.Width-1; x++)
                {
                    AddGroundCellV7(x, y);
                }
            }
            for (int y = 2; y < _level.Height - 1; y = y+4)
            {
                AddGroundCellV7(1, y);
            }
            for (int y = 4; y < _level.Height - 1; y = y + 4)
            {
                AddGroundCellV7(_level.Width-2, y);
            }
        }

        private void AddBerriesV7(int numberOfBerries)
        {
            int berriesAdded = 0;
            while (berriesAdded < numberOfBerries)
            {
                var randomX = _random.Next(_level.Width);
                var randomY = _random.Next(_level.Height);
                var cellToRemove = _level.Cells.First(cell => cell.CoordinateX == randomX && cell.CoordinateY == randomY);
                if (cellToRemove.Symbol == ".")
                {
                    var berry = new Berry(randomX, randomY, _level);

                    _level.Cells.Remove(cellToRemove);
                    _level.Cells.Add(berry);
                    berriesAdded++;
                }
            }
            
        }

        private void BuildGroundV18()
        {
            for (int y = 0; y < _level.Height; y++)
            {
                var midX = _level.Width / 2;

                var cell = _level.Cells.First(x => x.CoordinateX == midX && x.CoordinateY == y);
                var ground = new Ground(midX, y, _level);

                _level.Cells.Remove(cell);
                _level.Cells.Add(ground);
            }
            for (int x = 0; x < _level.Width; x++)
            {
                var midY = _level.Height / 2;

                var cell = _level.Cells.First(c => c.CoordinateY == midY && c.CoordinateX == x);
                var ground = new Ground(x, midY, _level);

                _level.Cells.Remove(cell);
                _level.Cells.Add(ground);

            }
        }

        private void BuildCage()
        {
            var cells = _level.Cells.Where(c => c.Symbol == "." && (c.CoordinateX == _level.Width - 1 || c.CoordinateX == 0)).ToList();
            foreach (var cell in cells)
            {
                var cage = new Cage(cell.CoordinateX, cell.CoordinateY, _level);

                _level.Cells.Remove(cell);
                _level.Cells.Add(cage);
            }

        }

        private void BuildCoin(int coinCount)
        {
            for (int i = 0; i < coinCount; i++)
            {
                var grounds = _level.Cells
                    .Where(x => x is Ground)
                    .ToList();
                var randomGroundIndex = _random.Next(grounds.Count);
                var randomGround = grounds[randomGroundIndex];

                var coin = new Coin(randomGround.CoordinateX, randomGround.CoordinateY, _level);
                _level.Cells.Remove(randomGround);
                _level.Cells.Add(coin);
            }
        }

        private void BuildDiamond()
        {
            {
                var cellPoints = new List<Point>
                    {
                        new Point(1, 1),
                        new Point(1, 2),
                        new Point(4, 1)
                    };

                foreach (var point in cellPoints)
                {
                    int[] moveX = { 0, 1, 1 };
                    int[] moveY = { 1, 0, 3 };

                    foreach (int x in moveX)
                    {
                        foreach (int y in moveY)
                        {
                            int newX = point.X + x;
                            int newY = point.Y + y;

                            var existingCell = _level.Cells.FirstOrDefault(cell => cell.CoordinateX == newX && cell.CoordinateY == newY);

                            if (existingCell != null)
                            {
                                var diamond = new Diamond(newX, newY, _level);
                                _level.Cells.Remove(existingCell);
                                _level.Cells.Add(diamond);
                            }
                        }
                    }
                }
            }
        }
        private void BuildChest() //сокровищница на уровне в случайном месте. Предполагатеся что можно будет пробиться к ней через стены
        {
            var randomX = Math.Abs(_random.Next(_level.Width));
            var randomY = Math.Abs(_random.Next(_level.Height));

            for (int x = randomX; x < randomX + 2; x++)
            {
                for (int y = randomY; y < randomY + 2; y++)
                {
                    var randomCell = _level.Cells.First(cell => cell.CoordinateX == x && cell.CoordinateY == y);
                    var cellChest = new Chest(x, y, _level);
                    _level.Cells.Remove(randomCell);
                    _level.Cells.Add(cellChest);
                }
            }
        }
    }
}
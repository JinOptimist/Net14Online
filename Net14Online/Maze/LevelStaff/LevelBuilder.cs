using Maze.Cells;
using Maze.Cells.Creatures;
using System.Drawing;

namespace Maze.LevelStaff
{
    public class LevelBuilder
    {
        private Level _level;
        private Random _random;

        public Level ChoiseLevelBuilder()
        {
            int typeBuilder;
            Console.WriteLine("Choise Level Builder");

            Console.WriteLine("1 - Base level Buildev0");
            Console.WriteLine("2 - Base level Buildev11");
            Console.WriteLine("3 - Base level Buildev7");

            while (!int.TryParse(Console.ReadLine(), out typeBuilder))
            {
                Console.WriteLine("Only number in range 1-3 allowed");
            }

            switch (typeBuilder)
            {
                case 1:
                    _level = BuildV0(40, 30);
                    break;
                case 2:
                    _level = BuildV11(30, 20);
                    break;
                case 3:
                    _level = BuildV7(30, 20);
                    break;
                default:
                    _level = BuildV0(30, 20);
                    break;
            }


            return _level;
        }

       
        public Level BuildV0(int width = 10, int height = 5, int seedForRandom = -1, int coinCount = 2, int berriesCount = 3, int trapsCount = 5, int SunCount = 2)
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
            BuildDiamond();
            BuildCoin(coinCount);
            BuildRing();
            BuildChest();
            BuildMoonV26();
            AddBerriesV7(berriesCount);
            BuildCage();
            BuildHero();
            BuildTrapRandom(trapsCount);
            BuildSun(SunCount);

            return _level;
        }
        public Level BuildV11(int width = 10, int height = 5)
        {

            _level = new Level();

            _level.Width = width;
            _level.Height = height;

            BuildWall();
            BuildGroundV18();
            BuildRing();
            BuildMoonV26();

            BuildHero();

            return _level;
        }

        public Level BuildV38(int width = 15, int height = 15)
        {
            _random = new Random();
            _level = new Level()
            {
                Height = height,
                Width = width
            };
            BuildWall();
            SetStartAndFinish(_level);
            var start = _level.Cells.SingleOrDefault(x=> x is Ground && x.CoordinateX == 0);
            var finish = _level.Cells.SingleOrDefault(x=> x is Ground && x.CoordinateX == _level.Width - 1);
            
            GenerateRandomWay(_level, start, finish);

            return _level;
        }

        private void GenerateRandomWay(Level level, BaseCell? start, BaseCell? finish)
        {
            
            var point = new Ground(start.CoordinateX, start.CoordinateY, level);
            var isFollowTheX = true;
           
             while (point.CoordinateX < finish.CoordinateX)
            {
                if (isFollowTheX)
                {
                    var randomStep = _random.Next(3);

                    for (int i = 0; i <= randomStep; i++)
                    {
                        var nextPoint = new Ground(point.CoordinateX + 1, point.CoordinateY, level);
                        var cell = level.Cells.FirstOrDefault(cell => cell.CoordinateX == nextPoint.CoordinateX && cell.CoordinateY == nextPoint.CoordinateY);
                        level.Cells.Remove(cell);
                        level.Cells.Add(nextPoint);
                        point = nextPoint;
                    }
                    isFollowTheX = false;
                }

                else
                {
                    var randomStep = _random.Next(3);

                    for (int i = 0; i <= randomStep; i++)
                    {
                        if (point.CoordinateY > finish.CoordinateY)
                        {
                            var nextPoint = new Ground(point.CoordinateX, point.CoordinateY - 1, level);
                            var cell = level.Cells.FirstOrDefault(cell => cell.CoordinateX == nextPoint.CoordinateX && cell.CoordinateY == nextPoint.CoordinateY);
                            point = nextPoint;
                            level.Cells.Remove(cell);
                        }
                        else
                        {
                            var nextPoint = new Ground(point.CoordinateX, point.CoordinateY + 1, level);
                            var cell = level.Cells.FirstOrDefault(cell => cell.CoordinateX == nextPoint.CoordinateX && cell.CoordinateY == nextPoint.CoordinateY);
                            point = nextPoint;
                            level.Cells.Remove(cell);
                        }
                        level.Cells.Add(point);
                    }

                    isFollowTheX = true;
                }
            };
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
            BuildHero();

            return _level;
        }

        private void BuildRing()
        {
            var corX = 0;
            var corY = 0;

            for (int j = 0; j < 5; j++)
            {
                var randomWall = _level.Cells.First(x => x.CoordinateX == corX && x.CoordinateY == corY);
                var ring = new Ring(corX, corY, _level);

                _level.Cells.Remove(randomWall);
                _level.Cells.Add(ring);

                corX += 2;
                corY += 1;
            }
        }
   

        private void BuildSun(int SunCount)
        {
            for (int i = 0; i < SunCount; i++)
            {
                var groundCells = _level.Cells.Where(cell => cell is Ground).ToList();

                if (groundCells.Count > 0)
                {

                    var randomGroundIndex = _random.Next(groundCells.Count);
                    var randomGround = groundCells[randomGroundIndex];


                    var sun = new Sun(randomGround.CoordinateX, randomGround.CoordinateY, _level);
                    _level.Cells.Remove(randomGround);
                    _level.Cells.Add(sun);
                }
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

        private void BuildMoonV26()
        {
            var radius = Math.Min(_level.Width, _level.Height) / 2;
            for (int i = -radius; i < radius; i++)
            {
                int X = _level.Width / 2;
                int Y = _level.Height / 2 + i;
                X += (int)Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(i, 2));
                var randomWall = _level.Cells.First(x => x.CoordinateX == X && x.CoordinateY == Y);
                var moon = new Moon(X, Y, _level);
                _level.Cells.Remove(randomWall);
                _level.Cells.Add(moon);
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

        private List<Ground> BuildGroundTask16()
        {
            var startX = 0;
            var startY = _random.Next(_level.Height);
            List<Ground> grounds = new List<Ground>();

            do
            {
                int randY;
                if (startY > 0 && startY <= _level.Height)
                {
                    randY = _random.Next(-1, 2);
                    startY = startY + randY;
                }
                if (startY == _level.Height)
                {
                    randY = 1;
                    startY = startY - randY;
                }
                if (startY == 0)
                {
                    randY = 1;
                    startY = startY + randY;
                }

                var randomWall = _level.Cells.First(x => x.CoordinateX == startX && x.CoordinateY == startY);
                var ground = new Ground(startX, startY, _level);

                _level.Cells.Remove(randomWall);
                _level.Cells.Add(ground);

                grounds.Add(ground);
                startX++;
            }
            while (startX < _level.Width);

            return grounds;
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
            for (int y = 1; y < _level.Height - 1; y = y + 2)
            {
                for (int x = 1; x < _level.Width - 1; x++)
                {
                    AddGroundCellV7(x, y);
                }
            }
            for (int y = 2; y < _level.Height - 1; y = y + 4)
            {
                AddGroundCellV7(1, y);
            }
            for (int y = 4; y < _level.Height - 1; y = y + 4)
            {
                AddGroundCellV7(_level.Width - 2, y);
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

            var cellPoints = new List<Point>
                    {
                        new Point(9, 4),
                        new Point(7, 3),
                        new Point(10, 6)
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
        /// <summary>
        /// сокровищница на уровне в случайном месте. Предполагатеся что можно будет пробиться к ней через стены
        /// </summary>
        private void BuildChest()
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

      
    

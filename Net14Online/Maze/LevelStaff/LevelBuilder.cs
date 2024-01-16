using Maze.Cells;
using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures;
using Maze.Helper;
using System.Drawing;

namespace Maze.LevelStaff
{
    public class LevelBuilder
    {
        private Level _level;
        private Random _random;
        private const bool SHOW_MAZE_GENERATION_SLOWLY = false;

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

            Console.Clear();

            switch (typeBuilder)
            {
                case 1:
                    _level = BuildV0(30, 20);
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

        public Level BuildV0(int width = 10,
            int height = 5,
            int seedForRandom = -1,
            int coinCount = 2,
            int berriesCount = 3,
            int trapsCount = 5,
            int sunCount = 5,
            int ringCount = 2,
            int secretCount = 3,
            int slimeCount = 2,
            int spiderCount = 7,
            int witchCount = 3,
            int uglySunCount = 10)
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
            BuildGroundSmart();
            BuildDiamond();
            BuildCoin(coinCount);
            BuildRing(ringCount);
            //BuildChest();
            BuildMoonV26();
            AddBerriesV7(berriesCount);
            BuildCages2();
            BuildTrapsAroundCoins(trapsCount);
            BuildSun(sunCount);
            BuildUglySun(uglySunCount);
            BuildSecret(secretCount, new Diamond(0, 0, _level), new Coin(0, 0, _level), new Ring(0, 0, _level));
            BuildPuddleV_10();

            //Generate creature
            BuildHero();
            BuildGoblinStupid(coinCount);
            BuildCentaur();
            BuildTerminatorV92(2);

            BuildBanker(3);
            BuildGoodMonster();
            BuildSnake();
            BuildGhost();
            BuildSpider(spiderCount);
            BuildSlime(slimeCount);
            BuildElf(ringCount);
            BuildWitch(witchCount);


            return _level;
        }

        private void BuildGhost()
        {
            var groundCell = _level.Cells.OfType<Ground>().ToList();
            var randomIndex = _random.Next(groundCell.Count);
            var cell = groundCell[randomIndex];
            var ghost = new Ghost(cell.CoordinateX, cell.CoordinateY, _level);
            _level.Creatures.Add(ghost);
        }

        private void BuildPit(Level level)
        {
            var grounds = level.Cells.Where(x => x is Ground).ToList();

            var pitCount = _random.Next(grounds.Count / 2);

            for (int i = 0; i < pitCount; i++)
            {
                var ground = grounds.GetRandom();

                var pit = new Pit(ground.CoordinateX, ground.CoordinateY, level);

                level.Cells.Remove(ground);
                level.Cells.Add(pit);
            }
        }

        private void BuildSnake(int snakeCount = 1)
        {
            for (int i = 0; i < snakeCount; i++)
            {
                var puddles = _level.Cells.OfType<Puddle>().ToList();
                var randomIndex = _random.Next(puddles.Count);
                var puddle = puddles[randomIndex];
                var snake = new Snake(puddle.CoordinateX, puddle.CoordinateY, _level);
                _level.Creatures.Add(snake);
            }
        }

        private void BuildPuddleV_10(int puddles = 1)
        {
            int puddlesAdded = 0;
            while (puddlesAdded < puddles)
            {
                var randomX = _random.Next(_level.Width);
                var randomY = _random.Next(_level.Height);
                var cellToRemove = _level.Cells.First(cell => cell.CoordinateX == randomX && cell.CoordinateY == randomY);
                if (cellToRemove.Symbol == ".")
                {
                    var puddle = new Puddle(randomX, randomY, _level);

                    _level.Cells.Remove(cellToRemove);
                    _level.Cells.Add(puddle);
                    puddlesAdded++;
                }
            }

        }

        private void BuildSlime(int slimeCount, ConsoleColor slimeColor = ConsoleColor.Blue)
        {
            for (int i = 0; i < slimeCount; i++)
            {
                var grounds = _level.Cells.OfType<Ground>().ToList();
                var randomIndex = _random.Next(grounds.Count);
                var ground = grounds[randomIndex];
                var slime = new Slime(ground.CoordinateX, ground.CoordinateY, _level, slimeColor);
                _level.Creatures.Add(slime);
            }
        }

        private void BuildGoodMonster()
        {
            var countGoodMonster = _level.Height / 2;
            for (int i = 0; i < countGoodMonster; i++)
            {
                var grounds = _level.Cells.OfType<Ground>().ToList();
                var randomIndex = _random.Next(grounds.Count);
                var ground = grounds[randomIndex];
                var goodMonster = new GoodMonster(ground.CoordinateX, ground.CoordinateY, _level);
                _level.Creatures.Add(goodMonster);
            }
        }


        private void BuildGoblinSlayer(int GoblinSlayerCount = 0)
        {
            for (int i = 0; i < GoblinSlayerCount; i++)
            {
                var ground = _level.GetRandomCell<Ground>();
                var GoblinSlayer = new GoblinSlayer(ground.CoordinateX, ground.CoordinateY, _level);
                _level.Creatures.Add(GoblinSlayer);
            }
        }

        private void BuildCentaur(int centaurCount = 1)

        {
            for (int i = 0; i < centaurCount; i++)
            {
                var grounds = _level.Cells.OfType<Ground>().ToList();
                var randomIndex = _random.Next(grounds.Count);
                var ground = grounds[randomIndex];
                var centaur = new Centaur(ground.CoordinateX, ground.CoordinateY, _level, ConsoleColor.Red);
                _level.Creatures.Add(centaur);
            }
        }

        private void BuildTerminatorV92(int termitantorCount)
        {
            for (int i = 0; i < termitantorCount; i++)
            {
                var coins = _level.Cells.OfType<Coin>().ToList();
                var randomIndex = _random.Next(coins.Count);
                var coin = coins[randomIndex];
                var terminator = new Terminator3000(coin.CoordinateX, coin.CoordinateY, _level, ConsoleColor.Yellow);
                _level.Creatures.Add(terminator);
            }
        }

        private void BuildElf(int ringCount)
        {
            for (int i = 0; i < ringCount; i++)
            {
                var rings = _level.Cells.OfType<Ring>().ToList();
                if (rings.Count > 0)
                {
                    var randomIndex = _random.Next(rings.Count);
                    var ring = rings[randomIndex];

                    var elf = new Elf(ring.CoordinateX, ring.CoordinateY, _level);
                    _level.Creatures.Add(elf);
                }
            }
        }
        private void BuildWitch(int witchCount)
        {
            for (int i = 0; i < witchCount; i++)
            {
                var groundCell = _level.Cells.OfType<Ground>().ToList();
                var randomIndex = _random.Next(groundCell.Count);
                var cell = groundCell[randomIndex];
                var witch = new Witch(cell.CoordinateX, cell.CoordinateY, _level, ConsoleColor.DarkCyan);
                _level.Creatures.Add(witch);
            }
        }

        private void BuildGoblinStupid(int goblinCount)
        {
            for (int i = 0; i < goblinCount; i++)
            {
                var coins = _level.Cells.OfType<Coin>().ToList();
                var randomIndex = _random.Next(coins.Count);
                var coin = coins[randomIndex];
                var goblin = new GoblinStupid(coin.CoordinateX, coin.CoordinateY, _level);
                _level.Creatures.Add(goblin);
            }
        }

        private void BuildBanker(int bankerCount = 1)
        {
            for (int i = 0; i < bankerCount; i++)
            {
                var ground = _level.GetRandomCell<Ground>();
                var banker = new Banker(ground.CoordinateX, ground.CoordinateY, _level);
                _level.Creatures.Add(banker);
            }
        }

        private void BuildGroundSmart()
        {
            var markToDestroy = new List<IBaseCell>();

            var randomIndex = _random.Next(_level.Cells.Count);
            var randomWall = _level.Cells[randomIndex];
            markToDestroy.Add(randomWall);

            while (markToDestroy.Any())
            {
                if (SHOW_MAZE_GENERATION_SLOWLY)
                {
                    var drawer = new LevelDrawer();
                    drawer.Draw(_level);
                    Thread.Sleep(200);
                }

                randomIndex = _random.Next(markToDestroy.Count);
                randomWall = markToDestroy[randomIndex];

                _level.ReplaceToGround(randomWall);
                markToDestroy.Remove(randomWall);

                var nearest = _level.GetNearCells<Wall>(randomWall);
                markToDestroy.AddRange(nearest);

                markToDestroy = markToDestroy
                    .Where(cell => _level.GetNearCells<Ground>(cell).Count() < 2)
                    .ToList();
            }
        }

        public Level BuildV11(int width = 10, int height = 5)
        {

            _level = new Level();

            _level.Width = width;
            _level.Height = height;

            BuildWall();
            BuildMoonV26();


            return _level;
        }

        public Level BuildV17(int width = 10, int height = 5, int seedForRandom = -1,
            int secretsCount = 5, int coinsCount = 3, int slimeCount = 2)
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
            BuildSecret(secretsCount, new Coin(0, 0, _level), new Diamond(0, 0, _level));
            BuildCoin(coinsCount);
            BuildHero();
            BuildSlime(slimeCount);

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

        private void BuildRing(int ringCount)
        {
            var random = new Random();

            for (int j = 0; j < ringCount; j++)
            {
                var emptyCells = _level.Cells.Where(cell => cell.Symbol == ".").ToList();

                if (emptyCells.Count == 0)
                {
                    break;
                }

                var randomEmptyCell = emptyCells[random.Next(emptyCells.Count)];

                // Pass _level to the constructor of Ring
                var ring = new Ring(randomEmptyCell.CoordinateX, randomEmptyCell.CoordinateY, _level);

                _level.Cells.Remove(randomEmptyCell);
                _level.Cells.Add(ring);
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
        private void BuildUglySun(int uglySunCount)
        {
            var crossroadCells = _level.Cells.Where(cell => _level.GetNearCells<Ground>(cell).Count > 2).ToList();
            for (int i = 0; i < uglySunCount && crossroadCells.Any(); i++)
            {
                var randomIndex = _random.Next(crossroadCells.Count);
                var randomCrossroad = crossroadCells[randomIndex];
                var uglysun = new UglySun(randomCrossroad.CoordinateX, randomCrossroad.CoordinateY, _level);
                _level.Cells.Remove(randomCrossroad);
                _level.Cells.Add(uglysun);
                crossroadCells.RemoveAt(randomIndex);
            }
        }

        private void BuildSun(int sunCount)
        {
            var crossroadCells = _level.Cells.Where(cell => _level.GetNearCells<Ground>(cell).Count > 2).ToList();
            for (int i = 0; i < sunCount && crossroadCells.Any(); i++)
            {
                var randomIndex = _random.Next(crossroadCells.Count);
                var randomCrossroad = crossroadCells[randomIndex];
                var sun = new Sun(randomCrossroad.CoordinateX, randomCrossroad.CoordinateY, _level);
                _level.Cells.Remove(randomCrossroad);
                _level.Cells.Add(sun);
                crossroadCells.RemoveAt(randomIndex);
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
            var potentialDeadEnds = new List<IBaseCell>();

            // Находим клетки, которые могут быть потенциальными тупиками
            foreach (var cell in _level.Cells)
            {
                var nearestWalls = _level.GetNearCells<Wall>(cell);

                if (nearestWalls.Count == 3)
                {
                    potentialDeadEnds.Add(cell);
                }
            }

            // Размещаем алмазы на месте тупиков
            foreach (var deadEnd in potentialDeadEnds)
            {
                var diamond = new Diamond(deadEnd.CoordinateX, deadEnd.CoordinateY, _level, ConsoleColor.DarkBlue);
                _level.ReplaceCell(deadEnd, diamond);
            }
        }



        private void BuildSecret(int numberOfSecrets, params BaseCell[] cellsForSecret)
        {
            for (int i = 0; i < numberOfSecrets; i++)
            {
                var grounds = _level.Cells
                    .Where(x => x is Ground)
                    .ToList();
                var randomGroundIndex = _random.Next(grounds.Count);
                var randomGround = grounds[randomGroundIndex];
                Point position = new Point(randomGround.CoordinateX, randomGround.CoordinateY);
                Secret secret = AddSecret(position, ConsoleColor.DarkMagenta, cellsForSecret);
            }
        }

        private Secret AddSecret(Point position, ConsoleColor color, params BaseCell[] cellsForSecret)
        {
            var oldCell = _level.Cells.First(x => x.CoordinateX == position.X && x.CoordinateY == position.Y);
            var secret = new Secret(position.X, position.Y, _level, color, cellsForSecret);
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

        private void ChangeWallCell(Point position, BaseCell newCell)
        {
            var wallCell = _level.Cells.SingleOrDefault(x => x.CoordinateX == position.X && x.CoordinateY == position.Y && x is Wall);
            if (wallCell != null)
            {
                _level.Cells.Remove(wallCell);
                _level.Cells.Add(newCell);
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

        private void BuildHero()
        {
            var ground = _level.Cells.First(x => x is Ground);

            var hero = new Hero(ground.CoordinateX, ground.CoordinateY, _level);

            _level.Hero = hero;
        }
        private void BuildTrapsAroundCoins(int maxTrapsCount)
        {
            for (int i = 0; i < maxTrapsCount; i++)
            {
                var coin = _level.GetRandomCell<Coin>();
                var nearestCell = _level.GetNearCells<Ground>(coin).FirstOrDefault();

                if (nearestCell != null)
                {
                    var trap = new Trap(nearestCell.CoordinateX, nearestCell.CoordinateY, _level);

                    _level.ReplaceCell(nearestCell, trap);
                }
            }
        }

        private void BuildTrapRandom(int trapsCount)
        {
            for (int i = 0; i < trapsCount; i++)
            {
                var randomX = _random.Next(_level.Width);
                var randomY = _random.Next(_level.Height);

                var randomWall = _level.Cells.First(x => x.CoordinateX == randomX && x.CoordinateY == randomY);
                var trap = new Trap(randomX, randomY, _level);

                _level.Cells.Remove(randomWall);
                _level.Cells.Add(trap);
            }
        }

        private void BuildSpider(int spiderCount)
        {
            var ground = _level.Cells.OfType<Ground>().ToList();

            for (int i = 0; i < spiderCount; i++)
            {
                var randomGround = ground.GetRandom();
                var spider = new Spider(randomGround.CoordinateX, randomGround.CoordinateY, _level);
                _level.Creatures.Add(spider);
            }
        }

        private void BuildCages2(int cageCount = 13)
        {
            var potentialCages = _level.Cells.Where(x => _level.GetNearCells<Ground>(x).Count == 4).ToList();

            for (int i = 0; i < cageCount && i < potentialCages.Count; i++)
            {
                var crossroad = potentialCages.GetRandom();
                var сage = new Cage(crossroad.CoordinateX, crossroad.CoordinateY, _level);

                _level.ReplaceCell(crossroad, сage);

            }
        }
    }
}
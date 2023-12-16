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
            Console.WriteLine("4 - Base level Buildev17");

            while (!int.TryParse(Console.ReadLine(), out typeBuilder))
            {
                Console.WriteLine("Only number in range 1-4 allowed");
            }

            Console.Clear();

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
                case 4:
                    _level = BuildV17(30, 20);
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
             int sunCount = 2)
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
            //BuildRing();
            //BuildChest();
            BuildMoonV26();
            AddBerriesV7(berriesCount);
            BuildCage();
            BuildTrapRandom(trapsCount);
            BuildSun(sunCount);
            BuildPuddleV_10();
            BuildMinotaur();
            //Generate creature
            BuildHero();
            BuildGoblinStupid(coinCount);
            BuildCentaur();
            BuildTerminatorV92(2);
            BuildGoodMonster();


            return _level;
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

        private void BuildGoblinStupid(int goblinCount)
        {
            for (int i = 0; i < goblinCount; i++)
            {
                var coin = _level.GetRandomCell<Coin>();
                var goblin = new GoblinStupid(coin.CoordinateX, coin.CoordinateY, _level);
                _level.Creatures.Add(goblin);
            }
        }

        private void BuildCentaur(int centaurCount = 1) 
        {
            for (int i = 0; i < centaurCount; i++)
            {
                var ground = _level.GetRandomCell<Ground>();
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

        private void BuildGroundSmart()
        {
            var markToDestroy = new List<BaseCell>();

            var randomWall = _level.GetRandomCell();
            markToDestroy.Add(randomWall);

            while (markToDestroy.Any())
            {
                if (SHOW_MAZE_GENERATION_SLOWLY)
                {
                    var drawer = new LevelDrawer();
                    drawer.Draw(_level);
                    Thread.Sleep(200);
                }

                randomWall = markToDestroy.GetRandom();

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
            BuildRing();
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

        private void BuildGroundRandom()
        {
            for (int i = 0; i < 15; i++)
            {
                var randomWall = _level.GetRandomCell();

                var ground = new Ground(randomWall.CoordinateX, randomWall.CoordinateY, _level);

                _level.Cells.Remove(randomWall);
                _level.Cells.Add(ground);
            }
        }

        private void BuildSun(int SunCount)
        {
            for (int i = 0; i < SunCount; i++)
            {
                var groundCells = _level.Cells.Where(cell => cell is Ground).ToList();

                if (groundCells.Count > 0)
                {
                    var randomGround = groundCells.GetRandom();

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

        private void AddGroundCellV7(int x, int y)
        {
            var wallToRemove = _level.Cells.First(cell => cell.CoordinateX == x && cell.CoordinateY == y);
            var ground = new Ground(x, y, _level);

            _level.Cells.Remove(wallToRemove);
            _level.Cells.Add(ground);
        }

        private void BuildGroundTask16()
        {
            var startX = 0;
            var startY = _random.Next(_level.Height);

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

                startX++;
            }
            while (startX < _level.Width);
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

        private void BuildRing()
        {
            var random = new Random();

            for (int j = 0; j < 10; j++)
            {
                var emptyCells = _level.Cells.Where(cell => cell.Symbol == ".").ToList();

                if (emptyCells.Count == 0)
                {
                    break;
                }

                var randomEmptyCell = emptyCells[random.Next(emptyCells.Count)];

                // Pass _level to the constructor of Ring
                var ring = new Ring(randomEmptyCell.CoordinateX, randomEmptyCell.CoordinateY, _level, 1);

                _level.Cells.Remove(randomEmptyCell);
                _level.Cells.Add(ring);
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

        private void AddBerriesV7(int numberOfBerries)
        {
            int berriesAdded = 0;
            while (berriesAdded < numberOfBerries)
            {
                var cellToRemove = _level.GetRandomCell();
                if (cellToRemove.Symbol == ".")
                {
                    var berry = new Berry(cellToRemove.CoordinateX, cellToRemove.CoordinateY, _level);

                    _level.Cells.Remove(cellToRemove);
                    _level.Cells.Add(berry);
                    berriesAdded++;
                }
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

        private void BuildCoin(int coinCount)
        {
            for (int i = 0; i < coinCount; i++)
            {
                var randomGround = _level.GetRandomCell<Ground>();

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
            foreach (var deadEnd in potentialDeadEnds)
            {
                var diamond = new Diamond(deadEnd.CoordinateX, deadEnd.CoordinateY, _level);
                _level.Cells.Remove(deadEnd);
                _level.Cells.Add(diamond);
            }
        }
        private void BuildMinotaur(int minotaurCount=4)
        {
            for (int i = 0; i < minotaurCount; i++)
            {
                var diamond = _level.GetRandomCell<Diamond>();
                var minotaur = new Minotaur(diamond.CoordinateX, diamond.CoordinateY, _level, ConsoleColor.Magenta);
                _level.Creatures.Add(minotaur);
            }
        }

        private void BuildSecret(int numberOfSecrets, params BaseCell[] cellsForSecret)
        {
            for (int i = 0; i < numberOfSecrets; i++)
            {
                var randomX = _random.Next(1, _level.Width - 1);
                var randomY = _random.Next(1, _level.Height - 1);
                Point position = new Point(randomX, randomY);
                Secret secret = AddSecret(position, ConsoleColor.DarkMagenta, cellsForSecret);

                Point startPathPosition = new Point(_level.Width / 2, _level.Height / 2);
                Point endPathPosition = new Point(secret.CoordinateX, secret.CoordinateY);
                BuildPaths(startPathPosition, endPathPosition);
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

        private void BuildTrapRandom(int trapsCount)
        {
            for (int i = 0; i < trapsCount; i++)
            {
                var randomCell = _level.GetRandomCell();
                var trap = new Trap(randomCell.CoordinateX, randomCell.CoordinateY, _level);

                _level.Cells.Remove(randomCell);
                _level.Cells.Add(trap);
            }
        }

        private void BuildPuddleV_10(int puddles = 1)
        {
            int puddlesAdded = 0;
            while (puddlesAdded < puddles)
            {
                var cellToRemove = _level.GetRandomCell();
                if (cellToRemove.Symbol == ".")
                {
                    var puddle = new Puddle(cellToRemove.CoordinateX, cellToRemove.CoordinateY, _level);

                    _level.Cells.Remove(cellToRemove);
                    _level.Cells.Add(puddle);
                    puddlesAdded++;
                }
            }

        }

        private void ChangeGroundToHouse()
        {
            for (int i = 0; i < _level.Cells.Count; i = i + 4)
            {
                if (_level.Cells[i] is Ground)
                {
                    var randomGround = _level.Cells.First(x => x.CoordinateX == _level.Cells[i].CoordinateX && x.CoordinateY == _level.Cells[i].CoordinateY);
                    House house = new House(_level.Cells[i].CoordinateX, _level.Cells[i].CoordinateY, _level);

                    _level.Cells.Remove(randomGround);
                    _level.Cells.Add(house);
                }
            }
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
        public Level BuildV10(int width = 10,
             int height = 5,
             int seedForRandom = -1,
             int coinCount = 2,
             int puddleCount = 5)
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
            BuildCoin(coinCount);
            BuildPuddleV_10();

            //Generate creature
            BuildHero();
            BuildGoblinStupid(coinCount);
            BuildSnake(puddleCount);

            return _level;
        }
        private void BuildSnake(int snakeCount)
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

        private void BuildThief()
        {
            var cellX = (_level.Width - _level.Hero.CoordinateX) / 2;
            var cellY = (_level.Height - _level.Hero.CoordinateY) / 2;

            var currentCell = _level.Cells.FirstOrDefault(c => c.CoordinateX == cellX && c.CoordinateY == cellY && c is Ground);

            if (currentCell != null)
            {
                var thief = new Thief(currentCell.CoordinateX, currentCell.CoordinateY, _level);
                _level.Creatures.Add(thief);
            }
            else
            {
                var cell = _level.GetNearCells<BaseCell>(currentCell).Where(c => !(c is Wall)).First();

                var thief = new Thief(cell.CoordinateX, cell.CoordinateY, _level);
                _level.Creatures.Add(thief);
            }
        }

    }
}

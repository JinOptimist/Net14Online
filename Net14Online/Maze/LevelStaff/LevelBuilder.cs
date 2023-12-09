using Maze.Cells;
using Maze.Cells.Creatures;
using System.Drawing;

namespace Maze.LevelStaff
{
    public class LevelBuilder
    {
        private Level _level;
        private Random _random;
        private BaseCell random;

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
            BildGoldMyRandom();
            BuilHeroRandom();
            return _level;
        }
        private void BuilHeroRandom() 
        { 
            var cell = _level.Cells.First (x =>x is Gold);
            var hero  = new Hero (cell.CoordinateX,cell.CoordinateY,_level);
            _level.Hero = hero;

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


        private void GetPrint(int goldx, int goldy)
        {
            var randomgoldx = _level.Cells.First(x => x.CoordinateX == goldx && x.CoordinateY == goldy);
            var gold = new Gold(goldx, goldy, _level);
            _level.Cells.Remove(randomgoldx);
            _level.Cells.Add(gold);
        }
        private void BildGoldMyRandom()
        {
            var goldx = _level.Height;
            var goldy = _level.Width;
            for (var i = 1; i < goldx - 1; i = i + 4)
            {
                for (var j = 1; j < goldy - 1; j++)
                {
                    GetPrint(i, j);
                }

            }
            for (var i = 1; i < goldx - 1; i = i + 4)
            {
                for (var j = 1; j < goldy - 1; j++)
                {
                    GetPrint(j, i);
                }

            }

        }

    }
}

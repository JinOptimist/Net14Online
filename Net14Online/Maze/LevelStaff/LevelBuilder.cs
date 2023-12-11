using Maze.Cells;
using Maze.Cells.Creatures;
using System;
using System.Drawing;
using System.Threading.Tasks.Sources;

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
            BuildSilver();
            BuildHero();
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
        private void BuildHero()
        {
            var silver = _level.Cells.First(x => x is Silver);

            var hero = new Hero(silver.CoordinateX, silver.CoordinateY, _level);

            _level.Hero = hero;
        }
        private void BuildHeroSilver (int X,int Y)
        {
            try
            {
                var randomsilver = _level.Cells.First(x => x.CoordinateX == X && x.CoordinateY == Y);
                var silver = new Silver(X, Y, _level);

                _level.Cells.Remove(randomsilver);
                _level.Cells.Add(silver);
            }
            catch (Exception ex)
            {

            }
          
        }
        private void BuildSilver()
        {
            var goldx = _level.Width;
            var goldy = _level.Height;

            for (var i = 1; i < goldx - 1; i =i+2)
            {
                for (var j = 1; j < goldy - 1; j++) 
                {
                    BuildHeroSilver(i, j);
                }
            }
            for (var i = 1; i < goldx - 1; i = i +4)
            {
                for (var j = 1; j < goldy - 1; j++)
                {
                    BuildHeroSilver(j, i);
                }
            }
           
        }
    }
}




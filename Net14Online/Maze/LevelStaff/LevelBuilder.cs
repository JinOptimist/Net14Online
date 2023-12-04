using Maze.Cells;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

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

        

        private void BildGoldMyRandom()
        {
            for (int i = 0; i <25; i++)
            {
                var  goldx = _random.Next(_level.Width);
                if ( goldx > _level.Width / 2)
                {
                    goldx = goldx - i / 2 - 1;
                }
                else if ( goldx < _level.Width / 2)
                {
                     goldx += 5;
                }
                var goldy = _random.Next(_level.Height);
                if (goldy > _level.Height / 2)
                {
                    goldy = goldy - i    / 2 - 1;
                }
                else
                {
                    goldy += 3;
                }

                var randomgoldx = _level.Cells.First(x => x.CoordinateX == goldx && x.CoordinateY == goldy);
                var gold = new Gold(goldx, goldy, _level);
                _level.Cells.Remove(randomgoldx);
                _level.Cells.Add(gold);




            }
            
             

            
            
            




        }

    } 
}

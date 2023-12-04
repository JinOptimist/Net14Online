using Maze.Cells;

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

        public Level BuildV5(int width = 10, int height = 5, int seedForRandom = -1)
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
            BuildSunS();

            return _level;
        }

        private void BuildSunS()
        {

           
            int x1 = _random.Next(_level.Width);
            int y1 = _random.Next(_level.Height);

            int x2, y2;
            do
            {
                x2 = _random.Next(_level.Width);
                y2 = _random.Next(_level.Height);
            } while (x2 == x1 && y2 == y1); 

           
            var sun1 = new Sun(x1, y1, _level);
            var sun2 = new Sun(x2, y2, _level);

           
            _level.Cells.Add(sun1);
            _level.Cells.Add(sun2);

     
            ConnectSuns(sun1, sun2);
        }
        private void ConnectSuns(Sun startSun, Sun endSun)
        {
            int currentX = startSun.CoordinateX;
            int currentY = startSun.CoordinateY;
            // не уверен в правильности этого цикла вообще
            while (currentX != endSun.CoordinateX || currentY != endSun.CoordinateY)
            {
                if (_level.Cells.All(cell => cell.CoordinateX != currentX || cell.CoordinateY != currentY || cell is Ground))
                {
                    var ground = new Ground(currentX, currentY, _level);
                    _level.Cells.Add(ground);
                }

                if (currentX != endSun.CoordinateX)
                {
                    currentX += Math.Sign(endSun.CoordinateX - startSun.CoordinateX);
                }

                if (currentY != endSun.CoordinateY)
                {
                    currentY += Math.Sign(endSun.CoordinateY - startSun.CoordinateY);
                }
            }

            //не знаю почему не соединяет данные точки землёй
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
    }
}

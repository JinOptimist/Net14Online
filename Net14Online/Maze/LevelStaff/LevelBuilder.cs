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


        private void BuildGroundV1()
        {
            int[] specificX = { 2, 4, 6 };
            int[] specificY = { 3, 7, 9 };
            foreach (int x in specificX)
            {
                foreach (int y in specificY)
                {
                    var existingCell = _level.Cells.First(cell => cell.CoordinateX == x && cell.CoordinateY == y);

                    if (existingCell == null)
                    {
                        var ground = new Ground(x, y, _level);
                        _level.Cells.Add(ground);
                    }
                }
            }
            //!!Код закомменчен в связи с заданием, ветка task_2, 30.11.2023!!
            //for (int i = 0; i < 15; i++)
            //{
            //    var randomX = _random.Next(_level.Width);
            //    var randomY = _random.Next(_level.Height);

            //    var randomWall = _level.Cells.First(x => x.CoordinateX == randomX && x.CoordinateY == randomY);
            //    var ground = new Ground(randomX, randomY, _level);

            //    _level.Cells.Remove(randomWall);
            //    _level.Cells.Add(ground);
            //}
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
        private void Diamond() 
        {
            foreach (var ground in _level.Cells)
            {
                int[] moveX = { 1, 0, -1 };
                int[] moveY = { 0, 1, -1 };
                foreach (int x in moveX)
                { 
                    foreach(int y in moveY)
                    {
                        int newX = ground.CoordinateX + x;
                        int newY = ground.CoordinateY + y;
                        var existingCell = _level.Cells.First(cell => cell.CoordinateX == x && cell.CoordinateY == y);

                        if (existingCell == null)
                        {
                            var diamond = new Diamond(newX, newY, _level); 
                            _level.Cells.Add(diamond);
                        }
                    }
                    
                }
                
            }
        }
    }
}

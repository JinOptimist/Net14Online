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
            //BuildGroundRandom();
            BuildGroundOnBorder();
            BuildExclamationHorizontal();
            //BuildExclamationRandom();
            

            return _level;
        }
        private void BuildExclamationHorizontal()
        {
            
            for (int i = 0; i < Math.Min(_level.Width, _level.Height); i++)
            {
                var exclamation = new Exclamation(i, i, _level);
                _level.Cells.Add(exclamation);
            }
        }
        /*private void BuildExclamationRandom()
        {
            for (int i = 0; i < 5; i++)  // Измените количество ячеек "!" по необходимости
            {
                var randomX = _random.Next(_level.Width);
                var randomY = _random.Next(_level.Height);

                var randomWall = _level.Cells.First(x => x.CoordinateX == randomX && x.CoordinateY == randomY);
                var exclamation = new Exclamation(randomX, randomY, _level);

                _level.Cells.Remove(randomWall);
                _level.Cells.Add(exclamation);
            }
        }*/
        private void BuildGroundOnBorder()
        {
            
            for (int i = 0; i < _level.Width; i++)
            {
                var ground = new Ground(i, 0, _level);
                _level.Cells.Add(ground);
            }

            
            for (int i = 1; i < _level.Height; i++)
            {
                var ground = new Ground(_level.Width - 1, i, _level);
                _level.Cells.Add(ground);
            }

            
            for (int i = _level.Width - 2; i >= 0; i--)
            {
                var ground = new Ground(i, _level.Height - 1, _level);
                _level.Cells.Add(ground);
            }

            
            for (int i = _level.Height - 2; i > 0; i--)
            {
                var ground = new Ground(0, i, _level);
                _level.Cells.Add(ground);
            }
        }
        /*private void BuildGroundRandom()
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
        }*/

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

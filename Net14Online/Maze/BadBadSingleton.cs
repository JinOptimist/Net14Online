namespace Maze
{
    /// <summary>
    /// Do not use it. Do not do something like it
    /// BAD PRACTICE
    /// </summary>
    public class BadBadSingleton
    {
        private BadBadSingleton() { }

        private static BadBadSingleton _instance;
        public static BadBadSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BadBadSingleton();
                }

                return _instance;
            }
        }
    }
}

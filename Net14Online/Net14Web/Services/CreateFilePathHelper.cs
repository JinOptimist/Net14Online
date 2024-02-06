namespace Net14Web.Services
{
    public class CreateFilePathHelper
    {
        private IWebHostEnvironment _webHostEnvironment;

        public CreateFilePathHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetStraightPath(params string[] directories)
        {
            var directoriesPath = Path.Combine(directories);
            var straightPath = Path.Combine(_webHostEnvironment.WebRootPath, directoriesPath);
            return straightPath;
        }

        public string GetCombinePath(params string[] directories)
        {
            return Path.Combine(directories);
        }
    }
}

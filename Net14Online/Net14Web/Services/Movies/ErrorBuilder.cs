using Net14Web.Models.Movies;

namespace Net14Web.Services.Movies
{
    public class ErrorBuilder
    {
        public ErrorBuilder()
        {
        }

        public ErrorViewModel BuildError(string title, string descrtiption)
        {
            var error = new ErrorViewModel
            {
                Title = title,
                Description = descrtiption
            };
            return error;
        }
    }
}

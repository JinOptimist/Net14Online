namespace Net14Web.Services.Movies
{
    public class RedirectBuilder
    {
        public RedirectBuilder()
        {
        }

        public object BuildRedirectMovieById(int id)
        {
            object movie = new { movieId = id };
            return movie;
        }

        public object BuildRedirectUserById(int id)
        {
            object user = new { userId = id };
            return user;
        }
    }
}

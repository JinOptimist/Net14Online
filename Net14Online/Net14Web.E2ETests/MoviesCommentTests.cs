using Net14Web.E2ETests.PagesSelector;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Net14Web.E2ETests
{
    public class MoviesCommentTests
    {
        private IWebDriver _driver;
        private LoginOnSite _loginOnSite;
        private Random _random;
        private string _commentText;

        private const string DESCRIPTION_COMMENT = "Hello world!";
        private const string MOVIES_SITE = "/movies/index/";
        private const string RANDOM_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        [OneTimeSetUp]
        public void Setup()
        {
            _loginOnSite = new LoginOnSite();
            _loginOnSite.LoginAsUser();
            _driver = _loginOnSite.Driver;
            _random = new Random();
        }

        [Test]
        public void OpenMoviePage()
        {
            _driver.Url = LoginOnSite.BASE_URL + MOVIES_SITE;
            var movieInput = _driver.FindElements(MoviePage.BUTTON_MOVIE_PAGE);
            if (movieInput.Count == 0)
            {
                Assert.That(false);
            }
            movieInput[0].SendKeys(Keys.Enter);

            var movieTitle = _driver.FindElements(MoviePage.MOVIE_TITLE);
            if (movieTitle.Count == 0)
            {
                Assert.That(false);
            }

            Assert.That(true);
        }

        [Test]
        public void AddUserComment()
        {
            OpenMoviePage();
            var inputAddComment = _driver.FindElement(CommentOnFilmSelectors.BUTTON_DESCRIPTION_COMMENT);
            _commentText = DESCRIPTION_COMMENT + " " + RandomString(10);
            inputAddComment.SendKeys(_commentText);

            Thread.Sleep(3000);
            var submitAddComment = _driver.FindElement(CommentOnFilmSelectors.BUTTON_ADD_COMMENT);
            submitAddComment.Click();

            Thread.Sleep(3000);
            var commentInfo = GetComment();
            Assert.That(LoginOnSite.USER_NAME == commentInfo[0]);
            Assert.That(_commentText == commentInfo[1]);
        }

        private string[] GetComment()
        {
            string[] commentInformation = new string[2];
            var userNameOnComment = _driver.FindElements(CommentOnFilmSelectors.USERNAME_ON_COMMENT);
            if (userNameOnComment.Count() == 0)
            {
                Assert.That(false);
            }
            commentInformation[0] = userNameOnComment[0].Text;
            var commentDesriptions = _driver.FindElements(CommentOnFilmSelectors.DESCRIPTION_COMMENT_TEXT);
            if (commentDesriptions.Count() == 0)
            {
                Assert.That(false);
            }
            commentInformation[1] = commentDesriptions[0].Text;
            return commentInformation;
        }


        [OneTimeTearDown]
        public void Down()
        {
            _loginOnSite.Driver.Quit();
        }

        public string RandomString(int length)
        {
            return new string(Enumerable.Repeat(RANDOM_CHARS, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}

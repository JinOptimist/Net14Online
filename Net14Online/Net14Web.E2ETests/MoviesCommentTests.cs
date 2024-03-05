using NUnit.Framework;
using OpenQA.Selenium;

namespace Net14Web.E2ETests
{
    public class MoviesCommentTests
    {
        private IWebDriver _driver;
        private LoginOnSite _loginOnSite;
        private Random _random;

        private const string DESCRIPTION_COMMENT = "Hello world!";
        private const string MOVIES_SITE = "/movies/index/";

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
            var movieInput = _driver.FindElements(By.CssSelector("a.movie-page"));
            if (movieInput.Count == 0)
            {
                Assert.That(false);
            }
            movieInput[0].SendKeys(Keys.Enter);

            var movieTitle = _driver.FindElements(By.CssSelector(".movie-title"));
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
            var inputAddComment = _driver.FindElement(By.CssSelector(".description-comment"));
            var commentText = DESCRIPTION_COMMENT + " " + RandomString(10);
            inputAddComment.SendKeys(commentText);

            var submitAddComment = _driver.FindElement(By.CssSelector(".btn-add-comment"));
            submitAddComment.Click();

            Thread.Sleep(2000);

            var userNameOnComment = _driver.FindElements(By.CssSelector(".comment-user-name"));
            if (userNameOnComment.Count() == 0)
            {
                Assert.That(false);
            }

            var commentDesriptions = _driver.FindElements(By.CssSelector(".comment-description"));
            if (commentDesriptions.Count() == 0)
            {
                Assert.That(false);
            }

            Assert.That(LoginOnSite.USER_NAME == userNameOnComment[0].Text);
            Assert.That(commentText == commentDesriptions[0].Text);
        }


        [OneTimeTearDown]
        public void Down()
        {
            _loginOnSite.Driver.Quit();
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}

using Net14Web.E2ETests.PagesSelector;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Net14Web.E2ETests
{
    public class DndTests
    {
        private IWebDriver driver;
        public const string BASE_URL = "https://localhost:7163";
        public const string DND_INDEX_URL = BASE_URL + "/Dnd/Index";

        public const string ADMIN_NAME = "admin";
        public const string ADMIN_PASSWORD = "123";

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = BASE_URL;
        }

        [Test]
        public void CheckIsLoginWork()
        {
            LoginAsAdmin();

            var loginLink = driver
                .FindElements(LayoutSelectors.LoginLink);

            Assert.That(loginLink.Count == 0);
            
            Logout();
        }

        [Test]
        public void CheckDndCoinClick()
        {
            LoginAsAdmin();
            if (!CheckIsAnyHeroExist())
            {
                CreateHero();
            }

            CheckIsCoinGrowing();
            
            Logout();
        }

        private void Logout()
        {
            driver.Url = BASE_URL;
            driver
                .FindElement(LayoutSelectors.LogoutLink)
                .Click();
        }

        private void CheckIsCoinGrowing()
        {
            driver.Url = DND_INDEX_URL;

            driver
                .FindElement(DndIndexPage.FirstHeroShortName)
                .Click();

            var heroBlock = driver
                .FindElement(DndIndexPage.FullHeroBlock);

            var coinsBeforeText = heroBlock
                .FindElement(DndIndexPage.HeroCoinsCount)
                .Text;

            heroBlock
                .FindElement(DndIndexPage.HeroCoinsIcon)
                .Click();

            var coinsAfterText = heroBlock
                .FindElement(DndIndexPage.HeroCoinsCount)
                .Text;

            var coinsBefore = int.Parse(coinsBeforeText);
            var coinsAfter = int.Parse(coinsAfterText);

            Assert.That(coinsBefore + 1 == coinsAfter);
        }

        private bool CheckIsAnyHeroExist()
        {
            // TODO
            return true;
        }

        private void CreateHero()
        {
            throw new NotImplementedException();
        }

        private void LoginAsAdmin()
        {
            driver.Url = BASE_URL;

            driver
                .FindElement(LayoutSelectors.LoginLink)
                .Click();

            driver
                .FindElement(LoginPage.UserNameInput)
                .SendKeys(ADMIN_NAME);
            driver
                .FindElement(LoginPage.PasswordInput)
                .SendKeys(ADMIN_PASSWORD);

            driver
               .FindElement(LoginPage.SubmitButton)
               .Click();
        }

        [OneTimeTearDown]
        public void Down()
        {
            driver.Quit();
        }
    }
}

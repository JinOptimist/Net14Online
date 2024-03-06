using Net14Web.E2ETests.PagesSelector;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Net14Web.E2ETests
{
    public class LoginOnSite
    {
        private IWebDriver driver;
        public const string BASE_URL = "https://localhost:7163";

        public const string ADMIN_NAME = "admin";
        public const string ADMIN_PASSWORD = "123";

        public const string USER_NAME = "user";
        public const string USER_PASSWORD = "123";

        public IWebDriver Driver => driver;

        public LoginOnSite()
        {
            driver = new ChromeDriver();
            driver.Url = BASE_URL;
        }

        public void LoginAsUser()
        {
            Login(USER_NAME, USER_PASSWORD);
        }

        public void LoginAsAdmin()
        {
            Login(ADMIN_NAME, ADMIN_PASSWORD);
        }

        private void Login(string loginName, string loginPassword)
        {
            driver.Url = BASE_URL;

            driver
                .FindElement(LayoutSelectors.LoginLink)
                .Click();

            driver
                .FindElement(LoginPage.UserNameInput)
                .SendKeys(loginName);
            driver
                .FindElement(LoginPage.PasswordInput)
                .SendKeys(loginPassword);

            driver
               .FindElement(LoginPage.SubmitButton)
               .Click();
        }

        public void Logout()
        {
            driver.Url = BASE_URL;
            driver
                .FindElement(LayoutSelectors.LogoutLink)
                .Click();
        }
    }
}

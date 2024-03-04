using OpenQA.Selenium;

namespace Net14Web.E2ETests.PagesSelector
{
    internal class LoginPage
    {
        public static By UserNameInput => By.CssSelector("#UserName");
        public static By PasswordInput => By.CssSelector("#Password");
        public static By SubmitButton => By.CssSelector("[type=submit]");
    }
}

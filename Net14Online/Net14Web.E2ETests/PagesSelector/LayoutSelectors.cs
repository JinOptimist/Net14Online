using OpenQA.Selenium;

namespace Net14Web.E2ETests.PagesSelector
{
    public class LayoutSelectors
    {
        public static By LoginLink => By.CssSelector(".login-link");
        public static By LogoutLink => By.CssSelector(".logout-link");
    }
}

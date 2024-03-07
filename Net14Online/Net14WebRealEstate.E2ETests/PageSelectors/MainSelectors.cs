using OpenQA.Selenium;

namespace TestProject1.PageSelectors;

public class MainSelectors
{
    public static By LoginLink => By.CssSelector(".login-link");
    public static By LogoutLink => By.CssSelector(".logout-link");
}
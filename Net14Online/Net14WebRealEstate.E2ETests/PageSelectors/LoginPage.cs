using OpenQA.Selenium;

namespace TestProject1.PageSelectors;

public class LoginPage
{
    public static By UserNameInput => By.CssSelector("#UserName");
    
    public static By PasswordInput => By.CssSelector("#Password");
    
    public static By SubmitButton => By.CssSelector("[type=submit]");
}
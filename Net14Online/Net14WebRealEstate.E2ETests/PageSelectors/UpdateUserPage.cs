using OpenQA.Selenium;

namespace TestProject1.PageSelectors;

public class UpdateUserPage
{
    public static By UserUpdateLink => By.CssSelector(".user-update-link");
    
    public static By UpdateUserNameInput => By.CssSelector("#Name");
    
    public static By UpdateUserAgeInput => By.CssSelector("#Age");
    
    public static By UpdateUserKindOfActivityInput => By.CssSelector("#KindOfActivity");
    
    public static By SubmitButton => By.CssSelector("[type=submit]");
}
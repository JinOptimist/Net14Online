using OpenQA.Selenium;

namespace TestProject1.PageSelectors;

public class AddUserPage
{
    public static By AddUserNameInput => By.CssSelector("#Name");
    
    public static By AddUserAgeInput => By.CssSelector("#Age");
    
    public static By AddKindOfActivityInput => By.CssSelector("#KindOfActivity");
    
    public static By SubmitButton => By.CssSelector("[type=submit]");
}
using OpenQA.Selenium;

namespace TestProject1.PageSelectors;

public class DeleteUserPage
{
    public static By DeleteUserLink => By.CssSelector(".delete-user-link");
}
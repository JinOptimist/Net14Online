using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using TestProject1.PageSelectors;

namespace Net14WebRealEstate.E2ETests;

public class RealEstateTests
{
    private IWebDriver driver;
    private const string BASE_URL = "https://localhost:7285/realEstate/Main";
    private const string DATA_BASE_URL = "https://localhost:7285/realEstate/DataBase";

    private const string ADMIN_NAME = "admin";
    private const string ADMIN_PASSWORD = "123";
    
    
    [OneTimeSetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Url = BASE_URL;
    }

    [Test]
    public void CheckIsLoginWork()
    {
        LoginAsAdmin();
        
        var loginLink = driver
            .FindElements(MainSelectors.LoginLink);

        Assert.That(loginLink.Count == 0);
        
        Logout();
    }

    [Test]
    public void CheckIsAddUser()
    {
        LoginAsAdmin();
        
        AddUser();
        
        driver.Url = BASE_URL;
        
        Logout();
    }

    [Test]
    public void CheckIsDeleteUser()
    {
        LoginAsAdmin();

        driver.Url = DATA_BASE_URL;
        
        driver.FindElement(DeleteUserPage.DeleteUserLink)
            .Click();

        driver.Url = BASE_URL;
        
        Logout();
    }

    [Test]
    public void CheckIsUpdateUser()
    {
        LoginAsAdmin();

        driver.Url = DATA_BASE_URL;
        
        UpdateUser();
        
        driver.Url = DATA_BASE_URL;
        
        Logout();
    }

    private void UpdateUser()
    {
       driver.FindElement(UpdateUserPage.UserUpdateLink)
           .Click();
       
       driver.FindElement(UpdateUserPage.UpdateUserNameInput)
           .SendKeys("test2");
       
       driver.FindElement(UpdateUserPage.UpdateUserAgeInput)
           .SendKeys("2");
       
       driver.FindElement(UpdateUserPage.UpdateUserKindOfActivityInput)
           .SendKeys("test2");
       
       driver.FindElement(UpdateUserPage.SubmitButton)
           .Click();
    }


    private void LoginAsAdmin()
    {
        driver.Url = BASE_URL;
        
        driver.FindElement(MainSelectors.LoginLink)
            .Click();
        
        driver.FindElement(LoginPage.UserNameInput)
            .SendKeys(ADMIN_NAME);
        
        driver.FindElement(LoginPage.PasswordInput)
            .SendKeys(ADMIN_PASSWORD);
        
        driver.FindElement(LoginPage.SubmitButton)
            .Click();
    }

    private void Logout()
    {
        driver.Url = BASE_URL;
        
        driver.FindElement(MainSelectors.LogoutLink)
            .Click();
    }

    private void AddUser()
    {
        driver.FindElement(DataBasePage.AddUserLink)
            .Click();
        
        driver.FindElement(AddUserPage.AddUserNameInput)
            .SendKeys("test");
        
        driver.FindElement(AddUserPage.AddUserAgeInput)
            .SendKeys("1");
        
        driver.FindElement(AddUserPage.AddKindOfActivityInput)
            .SendKeys("test");
        
        driver.FindElement(AddUserPage.SubmitButton)
            .Click(); 
    }
    
}
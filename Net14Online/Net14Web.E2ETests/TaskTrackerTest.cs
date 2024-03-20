using Net14Web.E2ETests.PagesSelector;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Net14Web.E2ETests
{
    public class TaskTrackerTest
    {
        private IWebDriver driver;
        public const string BASE_URL = "https://localhost:7163";
        public const string TASK_INDEX_URL = BASE_URL + "/TaskTracker/Index";

        public const string ADMIN_NAME = "admin";
        public const string ADMIN_PASSWORD = "123";

        public const string TASK_NAME = "task1";
        public const string TASK_DESCRIPTION = "test description";


        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = BASE_URL;
        }

        [Test]
        public void CheckAddNewTask()
        {
            LoginAsAdmin();

            CheckCreateNewTask();
            
            Logout();
        }

        private void Logout()
        {
            driver.Url = BASE_URL;
            driver
                .FindElement(LayoutSelectors.LogoutLink)
                .Click();
        }

        private void CheckCreateNewTask()
        {
            driver.Url = TASK_INDEX_URL;

            var taskCardsCountInitial = driver.FindElements(TaskTrackerIndexPage.TaskCard).Count;

            driver
                .FindElement(TaskTrackerIndexPage.AddTaskButton)
                .Click();
            Thread.Sleep(3000);

            driver
                .FindElement(TaskTrackerAddTaskPage.AddTaskNameInput)
                .SendKeys(TASK_NAME);
            driver
                .FindElement(TaskTrackerAddTaskPage.AddTaskDescriptionInput)
                .SendKeys(TASK_DESCRIPTION);

            driver
               .FindElement(TaskTrackerAddTaskPage.AddTaskSubmitButton)
               .Click();
            Thread.Sleep(3000);

            var taskCardsCountFinal = driver.FindElements(TaskTrackerIndexPage.TaskCard).Count;

            Assert.That(taskCardsCountInitial + 1 == taskCardsCountFinal);

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

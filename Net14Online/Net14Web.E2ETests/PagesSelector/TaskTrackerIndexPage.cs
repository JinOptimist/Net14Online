using OpenQA.Selenium;

namespace Net14Web.E2ETests.PagesSelector
{
    public class TaskTrackerIndexPage
    {
        public static By AddTaskButton => By.CssSelector(".navigation-button");
        public static By TaskCard => By.CssSelector(".photo-grid__card");
    }
}

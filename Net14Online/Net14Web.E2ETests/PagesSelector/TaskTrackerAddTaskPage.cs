using OpenQA.Selenium;

namespace Net14Web.E2ETests.PagesSelector
{
    public class TaskTrackerAddTaskPage
    {
        public static By AddTaskNameInput => By.CssSelector(".add-form__input_name");
        public static By AddTaskDescriptionInput => By.CssSelector(".add-form__input_description");
        public static By AddTaskSubmitButton => By.CssSelector(".add-form__button");
    }
}

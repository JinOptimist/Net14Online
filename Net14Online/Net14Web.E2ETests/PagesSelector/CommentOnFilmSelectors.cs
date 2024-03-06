using OpenQA.Selenium;

namespace Net14Web.E2ETests.PagesSelector
{
    internal class CommentOnFilmSelectors
    {
        public static By BUTTON_DESCRIPTION_COMMENT = By.CssSelector(".btn-description-comment");
        public static By BUTTON_ADD_COMMENT = By.CssSelector(".btn-add-comment");
        public static By USERNAME_ON_COMMENT = By.CssSelector(".comment-user-name");
        public static By DESCRIPTION_COMMENT_TEXT = By.CssSelector(".comment-description");
    }
}

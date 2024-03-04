using OpenQA.Selenium;

namespace Net14Web.E2ETests.PagesSelector
{
    public class DndIndexPage
    {
        public static By FirstHeroShortName => By.CssSelector(".hero.short:first-child .just-name");
        public static By FullHeroBlock => By.CssSelector(".hero.full");
        public static By HeroCoinsCount => By.CssSelector(".coin-block .coins-count");
        public static By HeroCoinsIcon => By.CssSelector(".coin-block .icon");
    }
}

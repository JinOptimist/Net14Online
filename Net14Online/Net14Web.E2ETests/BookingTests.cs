using Net14Web.E2ETests.PagesSelector;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net14Web.E2ETests
{
    public class BookingTests
    {
        private IWebDriver driver;
        public const string BASE_URL = "https://localhost:7163";
        public const string BOOKING_INDEX_URL = BASE_URL + "/BookingWeb/Index";

        public const string USER_NAME = "user";
        public const string USER_PASSWORD = "123";

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = BASE_URL;
        }

        [Test]
        public void CheckBookingSearch()
        {
            LoginAsUser();
            driver.Url = BOOKING_INDEX_URL;
            BookingSearchFieldInfo("Georgia", "Tbilisi", "13/01/2024", "12/01/2024");
        }

        [Test]
        public void CheckUpdateButton()
        {
            CheckBookingSearch();
            driver.FindElement(SearchResultPage.City)
                .SendKeys("Batumi");
            driver
                .FindElement(SearchResultPage.SubmitButton)
                .Click();

            Logout();
        }

        private void LoginAsUser()
        {
            driver.Url = BASE_URL;

            driver
                .FindElement(LayoutSelectors.LoginLink)
                .Click();

            driver
                .FindElement(LoginPage.UserNameInput)
                .SendKeys(USER_NAME);
            driver
                .FindElement(LoginPage.PasswordInput)
                .SendKeys(USER_PASSWORD);

            driver
               .FindElement(LoginPage.SubmitButton)
               .Click();
        }
        private void BookingSearchFieldInfo(string country, string city, string checkInDate, string checkOutDate)
        {
            driver
                .FindElement(BookingIndexPage.Country)
                .SendKeys(country);
            driver
                .FindElement(BookingIndexPage.City)
                .SendKeys(city);
            driver
                .FindElement(BookingIndexPage.Checkin)
                .SendKeys(checkInDate);
            driver
                .FindElement(BookingIndexPage.Checkout)
                .SendKeys(checkOutDate);
            driver
                .FindElement(BookingIndexPage.SubmitButton)
                .Click();
        }
        private void Logout()
        {
            driver.Url = BASE_URL;
            driver
                .FindElement(LayoutSelectors.LogoutLink)
                .Click();
        }

        [OneTimeTearDown]
        public void Down()
        {
            driver.Quit();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Net14Web.E2ETests.PagesSelector
{
    public class BookingIndexPage
    {
        public static By Country => By.Name("country");
        public static By City => By.Name("city");
        public static By Checkin => By.Name("checkin");
        public static By Checkout => By.Name("checkout");
        public static By SubmitButton => By.CssSelector("[type=submit]");
    }
}

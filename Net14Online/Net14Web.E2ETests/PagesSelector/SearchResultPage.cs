using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net14Web.E2ETests.PagesSelector
{
    public class SearchResultPage
    {
        public static By City => By.Name("city");
        public static By SubmitButton => By.CssSelector("[type=submit]");
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POM
{
    public class SearchPage :BasePage
    {
        public SearchPage(IWebDriver driver) :base (driver) 
        { 
        }

        public IWebElement SearchInputElement => driver.FindElement(By.Id("keyword"));
        public IWebElement SearchButtonElement => driver.FindElement(By.Id("search"));

        public override string GetActualResult()
        {
            try
            {
                var contactFirstName = driver.FindElement(By.CssSelector(".fname td")).Text;
                var contactLastName = driver.FindElement(By.CssSelector(".lname td")).Text;

                return $"{contactFirstName} {contactLastName}";
            }
            catch (Exception)
            {
                return driver.FindElement(By.Id("searchResult")).Text;
            }

        }

    }
}

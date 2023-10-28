using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POM
{
    public class ViewContactPage :BasePage
    {

        public ViewContactPage(IWebDriver driver)
            : base(driver)
        {
        }

        public override string GetActualResult()
        {
            var firstContactTable = driver.FindElement(By.Id("contact1"));

            var contactFirstName = firstContactTable.FindElement(By.CssSelector(".fname td")).Text;
            var contactLastName = firstContactTable.FindElement(By.CssSelector(".lname td")).Text;

            return $"{contactFirstName} {contactLastName}";
        }

        public string GetLastContactInfo()
        {
            var lastCOntactElement = driver.FindElement(By.CssSelector("main div a:last-child"));
            var firstName = lastCOntactElement.FindElement(By.CssSelector(".fname td")).Text;
            var lastName = lastCOntactElement.FindElement(By.CssSelector(".lname td")).Text;
            var email = lastCOntactElement.FindElement(By.CssSelector(".email td")).Text;
            return $"{firstName} {lastName} {email}";
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POM
{
    public class CreatePage :BasePage
    {
        public CreatePage(IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement FirstNameInput => driver.FindElement(By.Id("firstName"));
        public IWebElement LastNameInput => driver.FindElement(By.Id("lastName"));
        public IWebElement EmailInput => driver.FindElement(By.Id("email"));
        public IWebElement CreateButton => driver.FindElement(By.Id("create"));

        public override string GetActualResult()
        {
            var errMsg = driver?.FindElement(By.ClassName("err"))?.Text;
            return errMsg ?? string.Empty;
        }

    }
}

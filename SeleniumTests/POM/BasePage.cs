using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POM
{
    public abstract class BasePage
    {

        protected IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

    public void GoToPageBySideNavbar(string hrefAnchorValue)
    {
        var contactBtn = driver.FindElement(By.CssSelector($"aside ul li a[href={hrefAnchorValue}]"));
        contactBtn.Click();
    }
    public void GoToPageByButtonIconLink(string hrefAnchorValue)
    {
        var contactBtn = driver.FindElement(By.CssSelector($"main div a[href={hrefAnchorValue}"));
        contactBtn.Click();
    }

    public abstract string GetActualResult();
}
}

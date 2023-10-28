using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Tests
{
    public class BaseTests
    {
        protected IWebDriver driver;
        private string baseUrl = @"https://contactbook.velio4ka.repl.co/";

        [SetUp]

        public virtual void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = baseUrl;
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
            driver.Dispose();
        }

    }
}

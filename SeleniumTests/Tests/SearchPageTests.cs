using SeleniumTests.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Tests
{
    public class SearchPageTests :BaseTests
    {
        private SearchPage page;
        private string hrefValue = "\"/contacts/search\"";
        public override void Setup()
        {
            base.Setup();
            page = new SearchPage(driver);
        }

        [Test]
        public void SearchingByKeywordShouldBeAlbertEinsteinBySideNavbar()
        {
            var expectedName = "Albert Einstein";

            page.GoToPageBySideNavbar(hrefValue);
            page.SearchInputElement.SendKeys("albert");
            page.SearchButtonElement.Click();

            var actualName = page.GetActualResult();
            Assert.That(actualName, Is.EqualTo(expectedName));
        }

        [Test]
        public void SearchingByKeywordShouldBeAlbertEinsteinByButtonIcon()
        {
            var expectedName = "Albert Einstein";

            page.GoToPageByButtonIconLink(hrefValue);
            page.SearchInputElement.SendKeys("albert");
            page.SearchButtonElement.Click();

            var actualName = page.GetActualResult();
            Assert.That(actualName, Is.EqualTo(expectedName));
        }

        [Test]
        public void SearchingByNonExistingContactShouldNotReturnContactBySideNavbar()
        {
            var expectedResult = "No contacts found.";
            page.GoToPageBySideNavbar(hrefValue);
            page.SearchInputElement.SendKeys("Non-existing contact");
            page.SearchButtonElement.Click();

            var actualResult = page.GetActualResult();
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void SearchingByNonExistingContactShouldNotReturnContactByButtonIcon()
        {
            var expectedResult = "No contacts found.";
            page.GoToPageByButtonIconLink(hrefValue);
            page.SearchInputElement.SendKeys("Non-existing contact");
            page.SearchButtonElement.Click();

            var actualResult = page.GetActualResult();
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}

using SeleniumTests.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Tests
{
    public class ViewContactPageTests :BaseTests
    {
        private ViewContactPage page;
        private string hrefValue = "\"/contacts\"";
        public override void Setup()
        {
            base.Setup();
            page = new ViewContactPage(driver);
        }
        [Test]
        public void FirstContactShouldBeSteveJobsBySideNavbar()
        {
            var expectedName = "Steve Jobs";

            page.GoToPageBySideNavbar(hrefValue);

            var actualName = page.GetActualResult();
            Assert.That(actualName, Is.EqualTo(expectedName));
        }

        [Test]
        public void FirstContactShouldBeSteveJobsByButtonIcon()
        {
            var expectedName = "Steve Jobs";

            page.GoToPageByButtonIconLink(hrefValue);

            var actualName = page.GetActualResult();
            Assert.That(actualName, Is.EqualTo(expectedName));
        }
    }
}

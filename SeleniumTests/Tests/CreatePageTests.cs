using SeleniumTests.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Tests
{
    public class CreatePageTests :BaseTests
    {

        private CreatePage page;
        private ViewContactPage contactPage;
        private string hrefValue = "\"/contacts/create\"";

        public override void Setup()
        {
            base.Setup();
            page = new CreatePage(driver);
            contactPage = new ViewContactPage(driver);
        }

        [TestCase("", "TestLastName", "test@abv.bg", "Error: First name cannot be empty!")]
        [TestCase("TestFirstName", "", "test@abv.bg", "Error: Last name cannot be empty!")]
        [TestCase("TestFirstName", "TestLastName", "", "Error: Invalid email!")]
        [TestCase("TestFirstName", "TestLastName", "invalidEmail", "Error: Invalid email!")]
        public void CreateInvalidCOntactShouldReturnErrMsgBySideNavbar(string firstName, string lastName, string email, string errMsg)
        {
            var msg = errMsg;

            page.GoToPageBySideNavbar(hrefValue);
            page.FirstNameInput.SendKeys(firstName);
            page.LastNameInput.SendKeys(lastName);
            page.EmailInput.SendKeys(email);
            page.CreateButton.Click();

            var actualResult = page.GetActualResult();
            Assert.That(actualResult, Is.EqualTo(msg));
        }

        [TestCase("", "TestLastName", "test@abv.bg", "Error: First name cannot be empty!")]
        [TestCase("TestFirstName", "", "test@abv.bg", "Error: Last name cannot be empty!")]
        [TestCase("TestFirstName", "TestLastName", "", "Error: Invalid email!")]
        [TestCase("TestFirstName", "TestLastName", "invalidEmail", "Error: Invalid email!")]
        public void CreateInvalidCOntactShouldReturnErrMsgByButtonIcon(string firstName, string lastName, string email, string errMsg)
        {
            var msg = errMsg;

            page.GoToPageByButtonIconLink(hrefValue);
            page.FirstNameInput.SendKeys(firstName);
            page.LastNameInput.SendKeys(lastName);
            page.EmailInput.SendKeys(email);
            page.CreateButton.Click();

            var actualResult = page.GetActualResult();
            Assert.That(actualResult, Is.EqualTo(msg));
        }

        [Test]
        public void CreateFormShouldCreateSuccessfullNewContactBySideNavbar()
        {
            var data = GetRandomFirstLastAndEmail();
            var expectedResult = $"{data.firstName} {data.lastName} {data.email}";

            page.GoToPageBySideNavbar(hrefValue);
            page.FirstNameInput.SendKeys(data.firstName);
            page.LastNameInput.SendKeys(data.lastName);
            page.EmailInput.SendKeys(data.email);
            page.CreateButton.Click();

            var actualResult = contactPage.GetLastContactInfo();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        private (string firstName, string lastName, string email) GetRandomFirstLastAndEmail()
        {
            var firstName = Guid.NewGuid().ToString("X");
            var lastName = Guid.NewGuid().ToString("X");
            var email = $"{Guid.NewGuid()}@abv.bg";

            return (firstName, lastName, email);
        }
    }
}

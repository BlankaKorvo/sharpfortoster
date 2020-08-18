using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using CoreTestFrameWork;
using TestingFrameworkLibrary;

namespace TestingAddPerson
{
    [TestFixture]
    public class PersonModificationTests : TestBase

    {
        [Test]
        public void EditPersonTests()
        {  
            ContactData contactData = new ContactData() { FirstName = "Иван", MiddleName = "Васильевич", LastName = "Иванов" };
            appManager.Contacts.EditContact(contactData, 1);
        }
    }

}


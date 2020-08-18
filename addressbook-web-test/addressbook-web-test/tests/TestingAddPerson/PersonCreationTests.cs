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
    public class PersonCreationTests : TestBase 

    {
        [Test]
        public void CreatePersonTests()
        {
            ContactData contactData = new ContactData() { FirstName = "Василий", MiddleName = "Иванович", LastName = "Чапаев" };
            appManager.Contacts.CreateContact(contactData);
        }       
    }

}


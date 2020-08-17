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
    public class PersonRemovalTest : TestBase

    {
        [Test]
        public void RemovePersonTests()
        {
            appManager.Contacts
                .SelectContactFromAddressBook(2) //счет начинается с "2"
                .DeleteContactFromAddressBook();
            appManager.Auth.LogOut();
        }
    }

}

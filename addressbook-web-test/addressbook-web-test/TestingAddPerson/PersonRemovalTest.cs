﻿using System;
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
            navigationHelper.OpenHomePage();
            loginHelper.LogIn(new AccountData() { Username = "admin", Password = "secret" });
            contactHelper.SelectContactFromAddressBook(2); //счет начинается с "2"
            contactHelper.DeleteContactFromAddressBook();
            loginHelper.LogOut();
        }
    }

}

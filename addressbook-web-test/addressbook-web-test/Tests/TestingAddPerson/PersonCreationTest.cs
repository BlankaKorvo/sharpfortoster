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
    public class PersonCreationTest : TestBase 

    {
        [Test]
        public void CreatePersonTests()
        {
            appManager.Contacts
                    .FillContactForm(new ContactData() { FirstName = "Василий", MiddleName = "Иванович", LastName = "Чапаев" })
                    .SubmitContactCreation();
            appManager.Navigator.OpenHomePage();
            appManager.Auth.LogOut();
        }       
    }

}


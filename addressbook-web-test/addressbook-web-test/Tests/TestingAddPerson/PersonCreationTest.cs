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
            app.Navigator.OpenHomePage();
            app.Auth.LogIn(new AccountData() { Username = "admin", Password = "secret" });
            app.Contacts.FillContactForm(new ContactData() { FirstName = "Василий", MiddleName = "Иванович", LastName = "Чапаев" });
            app.Contacts.SubmitContactCreation();
            app.Navigator.OpenHomePage();
            app.Auth.LogOut();
        }       
    }

}


using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebTests.appmanager;
using WebTests.model;

namespace WebTests.addressBook.Contacts

{
    [TestFixture]
    public class ContactCreation : AuthTestBase 

    {
        [Test]
        public void CreateContact()
        {
            WebTests.model.ContactData contactData = new ContactData() { FirstName = "Василий", MiddleName = "Иванович", LastName = "Чапаев" };
            app.Contacts.CreateContact(contactData);
        }       
    }

}


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
    public class ContactRemoval : AuthTestBase
    {
        [Test]
        public void RemoveContact()
        {
            //prepair
            ContactData contact = new ContactData() { FirstName = "zhertva", MiddleName = "zhertva", LastName = "zhertva" };
            app.Contacts.CreateContactIfExist(contact);
            //action
            app.Contacts.RemoveContact(1);
        }
    }
}

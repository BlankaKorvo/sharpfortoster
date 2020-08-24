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
    public class ContactModification : AuthTestBase
    {
        [Test]
        public void EditContact()
        {
            ContactData contactData = new ContactData() { FirstName = "Иван", MiddleName = "Васильевич", LastName = "Иванов" };
            if (app.ContactAtomic.IsContactPresent())
            {
                app.Contacts.EditContact(contactData, 1);
            }
            else
            {
                app.Contacts.CreateContact(contactData);
                contactData.FirstName += contactData.FirstName;
                contactData.MiddleName += contactData.MiddleName;
                contactData.LastName += contactData.LastName;
                app.Contacts.EditContact(contactData, 1);
            }
        }
    }

}


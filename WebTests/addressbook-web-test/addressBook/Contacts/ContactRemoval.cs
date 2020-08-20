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

namespace WebTests.addressBook.Contacts
{
    [TestFixture]
    public class ContactRemoval : AuthTestBase

    {
        [Test]
        public void RemoveContact()
        {
            app.Contacts.RemoveContact(2);
        }
        [Test]
        public void RemoveContactSmart()
        {
            //action
            app.Contacts.RemoveContactSmart(2);
            //verification
            Assert.IsFalse(app.ContactAtomic.IsContactPresent());
        }
    }

}

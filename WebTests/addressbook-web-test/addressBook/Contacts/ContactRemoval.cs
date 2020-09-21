using System;
using System.Collections.Generic;
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
        [Test, Order(0)]
        public void RemoveContact()
        {
            //prepair
            ContactData contact = new ContactData() { FirstName = "zhertva", MiddleName = "zhertva", LastName = "zhertva" };
            app.Contacts.CreateContactIfExist(contact);
            List<ContactData> oldContacts = ContactData.GetAll(); // app.Contacts.GetContactList();

            //action
            app.Contacts.RemoveContact(0);

            //verification

            List<ContactData> newContacts = ContactData.GetAll(); //app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }

        //[Test]
        //public void RemoveAllContact()
        //{
        //    //prepair
        //    ContactData contact = new ContactData() { FirstName = "zhertva", MiddleName = "zhertva", LastName = "zhertva" };
        //    app.Contacts.CreateContactIfExist(contact);

        //    //action
        //    app.Contacts.RemoveAllContact(0);

        //    //verification
        //    Assert.IsFalse(app.ContactAtomic.IsContactPresent());
        //}

    }
}

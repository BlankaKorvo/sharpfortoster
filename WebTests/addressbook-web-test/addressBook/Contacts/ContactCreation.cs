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
    public class ContactCreation : AuthTestBase 
    {
        [Test]
        public void CreateContact()
        {
            //prepair
            ContactData contactData = new ContactData() { FirstName = "Василий", MiddleName = "Иванович", LastName = "Чапаев" };
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            
            //action
            app.Contacts.CreateContact(contactData);

            //verification
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
        [Test]
        public void CreateEmptyContact()
        {
            //prepair
            ContactData contactData = new ContactData() { FirstName = "", LastName = ""};
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            //action
            app.Contacts.CreateContact(contactData);

            //verification
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
        [Test]
        public void CreateBadContact()
        {
            //prepair
            ContactData contactData = new ContactData() { FirstName = "g'f" };
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            //action
            app.Contacts.CreateContact(contactData);

            //verification
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}


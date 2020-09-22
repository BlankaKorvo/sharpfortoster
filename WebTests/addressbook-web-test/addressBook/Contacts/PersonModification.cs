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
    public class ContactModification : AuthTestBase
    {
        [Test]
        public void EditContact()
        {
            //prepair
            ContactData contact = new ContactData() { FirstName = "Иван", MiddleName = "Васильевич", LastName = "Иванов" };
            app.Contacts.CreateContactIfExist(contact);
            List<ContactData> oldContacts = ContactData.GetAllContacts();// app.Contacts.GetContactList();
            contact.FirstName += contact.FirstName;
            contact.LastName += contact.LastName;
            contact.MiddleName += contact.MiddleName;
            
            //action
            app.Contacts.EditContact(contact, 0);

            //verification
            List<ContactData> newContacts = ContactData.GetAllContacts();// app.Contacts.GetContactList();
            oldContacts[0].FirstName = contact.FirstName;
            oldContacts[0].LastName = contact.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }

}


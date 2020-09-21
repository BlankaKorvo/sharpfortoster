using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using Newtonsoft.Json;
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
        private const string V = "";

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData()
                {
                    FirstName = GenerateRandomString(100),
                    MiddleName = GenerateRandomString(100),
                    LastName = GenerateRandomString(30)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile(string path)
        {
            return DataFromXmlFile<ContactData>(path);
        }
        public static IEnumerable<ContactData> ContactDataFromJsonFile(string path)
        {
            return DataFromJsonFile<ContactData>(path);
        }

        [Test, TestCaseSource(nameof(ContactDataFromXmlFile), new object[] { @"addressbook-web-test\contacts.xml" })]
        public void CreateContactFormXml(ContactData contactData)
        {
            //prepair
            List<ContactData> oldContacts = ContactData.GetAll(); //app.Contacts.GetContactList();

            //action
            app.Contacts.CreateContact(contactData);

            //verification
            List<ContactData> newContacts = ContactData.GetAll(); //app.Contacts.GetContactList();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
        [Test, TestCaseSource(nameof(ContactDataFromJsonFile), new object[] { @"addressbook-web-test\contacts.json" })]
        public void CreateContactFromJson(ContactData contactData)
        {
            //prepair
            List<ContactData> oldContacts = ContactData.GetAll(); //app.Contacts.GetContactList();

            //action
            app.Contacts.CreateContact(contactData);

            //verification
            List<ContactData> newContacts = ContactData.GetAll();  //app.Contacts.GetContactList();
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
            List<ContactData> oldContacts = ContactData.GetAll(); //app.Contacts.GetContactList();

            //action
            app.Contacts.CreateContact(contactData);

            //verification
            List<ContactData> newContacts = ContactData.GetAll(); //app.Contacts.GetContactList();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}


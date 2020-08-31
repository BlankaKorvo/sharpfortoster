using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebTests.appmanager;
using WebTests.model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebTests.appmanager
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper CreateContact(ContactData contactData)
        {
            manager.Navigator.OpenHomePage();
            manager.ContactAtomic.OpenEditAddressBookEntry();
            manager.ContactAtomic.FillContactForm(contactData);
            manager.ContactAtomic.SubmitContactCreation();
            return this;
        }

        public ContactHelper EditContact(ContactData contactData, int index)
        {
            manager.Navigator.ReturnToHomePage();
            manager.ContactAtomic.SelectContactForEdition(index);
            manager.ContactAtomic.FillContactForm(contactData);
            manager.ContactAtomic.SubmitEditContact();
            return this;
        }

        public ContactHelper RemoveContact(int index)
        {
            manager.Navigator.ReturnToHomePage();
            manager.ContactAtomic.SelectContact(index); //счет начинается с "2"
            manager.ContactAtomic.RemovalContact();
            return this;
        }
        public ContactHelper RemoveAllContact(int index)
        {
            manager.Navigator.ReturnToHomePage();
            manager.ContactAtomic.SelectAllContact(); //счет начинается с "2"
            manager.ContactAtomic.RemovalContact();
            return this;
        }
        public ContactHelper CreateContactIfExist(ContactData contactData)
        {
            if (!manager.ContactAtomic.IsContactPresent())
            {
                CreateContact(contactData);
            }
            return this;
        }
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    IReadOnlyList<IWebElement> tags = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData() 
                    { 
                        FirstName = tags[2].Text, LastName = tags[1].Text 
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }
    }
}

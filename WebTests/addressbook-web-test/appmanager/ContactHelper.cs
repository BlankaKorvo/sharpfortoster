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

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            manager.ContactAtomic.InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");

            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string secHomePhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string webAddress = driver.FindElement(By.Name("address2")).GetAttribute("value");


            return new ContactData()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                SecondaryHomePhone = secHomePhone,
                HomePage = webAddress,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3                              
            };
        }

        internal ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            string webAddress = cells[9].Text;
           
            return new ContactData()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones,
                HomePage = webAddress
            };
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

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
        internal ContactHelper EditContact(ContactData contactData, int index)
        {
            manager.Navigator.ReturnToHomePage();
            manager.ContactAtomic.SelectContactForEdition(index);
            manager.ContactAtomic.FillContactForm(contactData);
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        public ContactHelper EditContactSmart(ContactData contact, int index) //пока не придумал как вытаскивать параметры объекта и чекать на ноль
        {
            if (manager.ContactAtomic.IsContactPresent())
            {
                EditContact(contact, index);
            }
            else
            {
                CreateContact(contact);
                contact.FirstName += contact.FirstName;
                contact.MiddleName += contact.MiddleName;
                contact.LastName += contact.LastName;
                EditContact(contact, index);
            }
            return this;
        }
        internal ContactHelper RemoveContact(int index)
        {
            manager.Navigator.ReturnToHomePage();
            manager.ContactAtomic.SelectContact(index); //счет начинается с "2"
            manager.ContactAtomic.DeleteContactFromAddressBook();
            return this;
        }
        public ContactHelper RemoveContactSmart(int index)
        {
            if (manager.ContactAtomic.IsContactPresent())
            {
                RemoveContact(index);
            }
            else
            {
                ContactData contact = new ContactData() { FirstName = "zhertva", MiddleName = "zhertva", LastName = "zhertva" };
                CreateContact(contact);
                RemoveContact(index);
            }
            return this;
        }
    }
}

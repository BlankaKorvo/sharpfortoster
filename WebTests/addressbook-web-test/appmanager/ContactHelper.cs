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
using System.Security.Cryptography;
using System.Reflection;

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

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            
            manager.ContactAtomic.SelectContactForEdition(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");

            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string secAddress = driver.FindElement(By.Name("address2")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string faxPhone = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string secHomePhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string webAddress = driver.FindElement(By.Name("homepage")).GetAttribute("value");


            return new ContactData()
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                NickName = nickName,
                Address = address,
                SecondaryAddress = secAddress,
                Title = title,
                Company = company,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                FaxPhone = faxPhone,
                SecondaryHomePhone = secHomePhone,
                HomePage = webAddress,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3
            };
        }

        internal string SetContactInformationFromObject(int index)
        {
            ContactData contact = GetContactInformationFromEditForm(index);
            string r = "\r";
            string n = "\n";
            string rn = r + n;
            if (contact.FirstName != "")
            {
                contact.FirstName = contact.FirstName + " ";
            }
            if (contact.MiddleName != "")
            {
                contact.MiddleName = contact.MiddleName + " ";
            }
            if (contact.LastName != "")
            {
                contact.LastName = contact.LastName + rn;
            }
            if (contact.NickName != "")
            {
                contact.NickName = contact.NickName + rn;
            }
            if (contact.Title != "")
            {
                contact.Title = contact.Title + rn;
            }
            if (contact.Company != "")
            {
                contact.Company = contact.Company + rn;
            }
            if (contact.Address != "")
            {
                contact.Address = contact.Address + rn + rn;
            }
            if (contact.HomePhone != "")
            {
                contact.HomePhone = "H: " + contact.HomePhone + rn;
            }
            if (contact.WorkPhone != "")
            {
                contact.WorkPhone = "W: " + contact.WorkPhone + rn;
            }
            if (contact.FaxPhone != "")
            {
                contact.FaxPhone = "F: " + contact.FaxPhone + rn + rn;
            }
            if (contact.MobilePhone != "")
            {
                contact.MobilePhone = "M: " + contact.MobilePhone;
            }
            if (contact.Email1 != "")
            {
                contact.Email1 = contact.Email1 + rn;
            }
            if (contact.Email2 != "")
            {
                contact.Email2 = contact.Email2 + rn + rn;
            }
            if (contact.Email3 != "")
            {
                contact.Email3 = contact.Email3 + rn + rn + rn;
            }
            return
                contact.FirstName +
                contact.MiddleName +
                contact.LastName +
                contact.NickName +
                contact.Title +
                contact.Company +
                contact.Address +
                contact.HomePhone +
                contact.WorkPhone +
                contact.MobilePhone +
                contact.FaxPhone +
                contact.Email1 +
                contact.Email2 +
                contact.Email3 +
                contact.SecondaryAddress; // И т.д.и т.п.              
        }

        internal string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            manager.ContactAtomic.GoToContactDetails(index);
            IWebElement content = driver.FindElement(By.XPath("//div[@id='content']"));
            return content.Text;
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
            manager.ContactAtomic.InitContactModification(index);
            manager.ContactAtomic.FillContactForm(contactData);
            manager.ContactAtomic.SubmitEditContact();
            return this;
        }

        public ContactHelper RemoveContact(int index)
        {
            manager.Navigator.ReturnToHomePage();
            manager.ContactAtomic.SelectContact(index); //счет начинается с "2"
            manager.ContactAtomic.RemovalContact();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
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
        public int GetNumberOfSearchResults()
        {
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

    }
}

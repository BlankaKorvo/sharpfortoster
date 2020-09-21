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
    class ContactInformationTests : AuthTestBase
    {

        [Test]
        public void TestDetailsContactInformation()
        {
            //prepair
            ContactData contactData = new ContactData() { FirstName = "Василий ака Чапай", MiddleName = "Иванович", LastName = "Чапаев", NickName = "nick name", Company = "Рога и копыта", Title = "title", FaxPhone = "+894665482 25", Address = "address\naddress\n\nbtestdetails", SecondaryAddress = "sec addre\nss", HomePhone = "+7(456)156 55 25", WorkPhone = "+7 926 456-45-64", Email1 = "123@112.99", Email3 = "ks;s@lhdf.99"};
            app.Contacts.CreateContact(contactData);

            //action
            string fromObject = app.Contacts.SetContactInformationFromObject(0).Trim();
            string fromDetails = app.Contacts.GetContactInformationFromDetails(0).Trim();

            
            //verification
            Assert.AreEqual(fromDetails, fromObject);
        }
        [Test]
        public void TestTableContactInformation()
        {
            //prepair
            ContactData contactData = new ContactData() { FirstName = "Василий ака Чапай", MiddleName = "Иванович", LastName = "Чапаев", Address = "Thisf\nksfl\ntesttable", HomePhone = "+7(456)156 55 25", WorkPhone = "+7 926 456-45-64", Email1 = "123@112.99", Email3 = "ks;s@lhdf.99", HomePage = "vk.com" };
            //app.Contacts.CreateContact(contactData);

            //action
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.FirstName, fromForm.FirstName);
            Assert.AreEqual(fromTable.LastName, fromForm.LastName);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            //Assert.AreEqual(fromTable.HomePage, fromForm.HomePage);
        }
    }

}

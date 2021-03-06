﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebTests.appmanager;
using WebTests.model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace WebTests.appmanager.atomicHelpers
{
    public class ContactHelperAtomic : HelperBase
    {
        public ContactHelperAtomic(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelperAtomic SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelperAtomic SubmitEditContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelperAtomic FillContactForm(ContactData personData)
        {
            FillinigTextField(By.Name("firstname"), personData.FirstName);
            FillinigTextField(By.Name("middlename"), personData.MiddleName);
            FillinigTextField(By.Name("lastname"), personData.LastName);
            FillinigTextField(By.Name("nickname"), personData.NickName);
            FillinigFileField(By.Name("photo"), personData.Photo);
            FillinigTextField(By.Name("title"), personData.Title);
            FillinigTextField(By.Name("company"), personData.Company);
            FillinigTextField(By.Name("address"), personData.Address);
            FillinigTextField(By.Name("home"), personData.HomePhone);
            FillinigTextField(By.Name("mobile"), personData.MobilePhone);
            FillinigTextField(By.Name("work"), personData.WorkPhone);
            FillinigTextField(By.Name("fax"), personData.FaxPhone);
            FillinigTextField(By.Name("email"), personData.Email1);
            FillinigTextField(By.Name("email2"), personData.Email2);
            FillinigTextField(By.Name("email3"), personData.Email3);
            FillinigTextField(By.Name("homepage"), personData.HomePage);
            FillinigTextField(By.Name("byear"), personData.BirthYear);
            FillinigTextField(By.Name("ayear"), personData.AnniversaryYear);
            FillinigTextField(By.Name("address2"), personData.SecondaryAddress);
            FillinigTextField(By.Name("phone2"), personData.SecondaryHomePhone);
            FillinigTextField(By.Name("notes"), personData.Note);
            FillingDropDownList(By.Name("bday"), personData.BirthDay);
            FillingDropDownList(By.Name("bmonth"), personData.BirthMonth);
            FillingDropDownList(By.Name("aday"), personData.AnniversaryDay);
            FillingDropDownList(By.Name("amonth"), personData.AnniversaryMonth);

            //driver.FindElement(By.Name("new_group")).Click();
            //new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText("ркка"); /// Доделать..хз пока как получать список групп для выбора
            //driver.FindElement(By.Name("new_group")).Click();
            return this;
        }

        internal ContactHelperAtomic GoToContactDetails(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelperAtomic InitContactModification(int index)
        {
            manager.Navigator.OpenHomePage();
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelperAtomic SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tr[" + (index+2) /*счет начинается с "2"*/ + "]/td/input")).Click();
            return this;
        }
        //public ContactHelperAtomic SelectContact(string beacon)
        //{
        //    SortBeaconContact(beacon);
        //    driver.FindElement(By.XPath("//tr[2]/td/input")).Click();
        //    return this;
        //}

        public ContactHelperAtomic SelectContactForEdition(int index)
        {
            manager.Navigator.OpenHomePage();
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
            return this;
        }
        public ContactHelperAtomic OpenEditAddressBookEntry()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelperAtomic RemovalContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept(); //работает через раз. Плавающая бага нераспознанной природы.
           ///Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$")); //работает стабильно
            contactCache = null;
            return this;
        }
        public bool IsContactPresent()
        {
            manager.Navigator.ReturnToHomePage();
            return IsElementPresent(By.ClassName("center"));
        }
        public ContactHelperAtomic SelectAllContact()
        {
            driver.FindElement(By.Id("MassCB")).Click();
            return this;
        }
        public string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email.Replace("r", "").Replace("n", "");            
        }
        public ContactHelperAtomic SortBeaconContact(string text)
        {
            manager.Navigator.OpenHomePage();
            driver.FindElement(By.Name("searchstring")).Click();
            driver.FindElement(By.Name("searchstring")).Clear();
            driver.FindElement(By.Name("searchstring")).SendKeys(text);
            return this;
        }
    }
}

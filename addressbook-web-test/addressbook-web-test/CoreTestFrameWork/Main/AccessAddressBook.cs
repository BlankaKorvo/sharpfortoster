using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTestFrameWork.Main
{
    //class LogonAddressBook : AccountData
    //{
    //    public LogonAddressBook(string user, string pass) : base(user, pass) { }

    //}
    class AccessAddressBook 
    {
        private IWebDriver _driver;
        public AccessAddressBook(IWebDriver driver)
        {
            _driver = driver;
        }
        public void LogIn(AccountData account)
        {
            _driver.FindElement(By.Name("user")).Click();
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys(account.Username);
            _driver.FindElement(By.Name("pass")).Click();
            _driver.FindElement(By.Name("pass")).Clear();
            _driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            _driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void LogOut()
        {
            _driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}

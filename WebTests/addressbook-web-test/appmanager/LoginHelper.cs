using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTests.appmanager;
using WebTests.model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebTests.appmanager
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void LogIn(AccountData account)
        {
            if (manager.AuthAtomic.IsLoggedIn())
            {
                if (manager.AuthAtomic.IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            FillinigTextField(By.Name("user"), account.Username);
            FillinigTextField(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        public void Logout()
        {
            if (manager.AuthAtomic.IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }            
        }
    }
}

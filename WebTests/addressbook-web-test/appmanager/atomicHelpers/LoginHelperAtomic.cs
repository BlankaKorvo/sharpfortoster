using System;
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
    public class LoginHelperAtomic :HelperBase
    {
        public LoginHelperAtomic(ApplicationManager manager) : base(manager)
        { }
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                    == "(" + account.Username + ")";
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }
    }
}
